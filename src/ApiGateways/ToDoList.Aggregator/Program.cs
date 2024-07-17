using Polly.Extensions.Http;
using Polly;
using Serilog;
using Commom.Logging;
using ToDoList.Aggregator.Services.TodoList;
using ToDoList.Aggregator.Services.GrpcUser;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(SeriLogger.Configure);

var configuration = builder.Configuration;
builder.Services.AddHttpClient<IListService, ListService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:TodoList"]))                
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());

builder.Services.AddHttpClient<ITaskService, TaskService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:TodoList"]))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());

builder.Services.AddHttpClient<IChecklistService, ChecklistService>(c =>
                c.BaseAddress = new Uri(configuration["ApiSettings:TodoList"]))
                .AddPolicyHandler(GetRetryPolicy())
                .AddPolicyHandler(GetCircuitBreakerPolicy());


// Grpc Configuration
builder.Services.AddGrpcClient<Grpc.Users.API.User.UserClient>
    (o => o.Address = new Uri(configuration["ApiSettings:GrpcUser"]))
    .AddPolicyHandler(GetRetryPolicy())
    .AddPolicyHandler(GetCircuitBreakerPolicy()); 

builder.Services.AddScoped<GrpcUserService>();

var app = builder.Build();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseHttpsRedirection();

app.UseAuthorization();

app.MapControllers();

app.Run();

public partial class Program
{
    private static IAsyncPolicy<HttpResponseMessage> GetRetryPolicy()
    {
        // In this case will wait for
        //  2 ^ 1 = 2 seconds then
        //  2 ^ 2 = 4 seconds then
        //  2 ^ 3 = 8 seconds then
        //  2 ^ 4 = 16 seconds then
        //  2 ^ 5 = 32 seconds

        return HttpPolicyExtensions
                .HandleTransientHttpError()
                .WaitAndRetryAsync(
                    retryCount: 5,
                    sleepDurationProvider: retryAttempt => TimeSpan.FromSeconds(Math.Pow(2, retryAttempt)),
                    onRetry: (exception, retryCount, context) =>
                    {
                        Log.Error($"Retry {retryCount} of {context.PolicyKey} at {context.OperationKey}, due to: {exception}.");
                    });

    }

    private static IAsyncPolicy<HttpResponseMessage> GetCircuitBreakerPolicy()
    {
        return HttpPolicyExtensions
                .HandleTransientHttpError()
                .CircuitBreakerAsync(
                    handledEventsAllowedBeforeBreaking: 5,
                    durationOfBreak: TimeSpan.FromSeconds(30)
                );
    }
}
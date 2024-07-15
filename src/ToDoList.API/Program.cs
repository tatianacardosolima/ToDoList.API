using Commom.Logging;
using Microsoft.AspNetCore.Diagnostics;
using Prometheus;
using Serilog;
using System.Net;
using ToDoList.API;
using ToDoList.API.Middlewares;
using ToDoList.API.Setup;
using ToDoList.Shared.Exceptions;
using ToDoList.Shared.Responses;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Host.UseSerilog(SeriLogger.Configure);

builder.Services.AddTodoListDependency(builder.Configuration);
var app = builder.Build();

app.UseApiServices();

// Configure the HTTP request pipeline.
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseMetricServer();
app.UseHttpMetrics();
app.UseHttpsRedirection();

Summary endpointRequestDurationMetric = PrometheusSetup.CreateEndpointRequestDurationSummaryMetric();
Counter endpointRequestCounterMetric = PrometheusSetup.CreateEndpointRequestCounterMetric();
Histogram endpointRequestHistogramMetric = PrometheusSetup.CreateEndpointRequestDurationHistogramMetric();
Gauge gaugeMetric = PrometheusSetup.CreateEndpointRequestGaugeMetric();
app.UsePrometheusMiddleware(endpointRequestCounterMetric, endpointRequestDurationMetric,
                endpointRequestHistogramMetric, gaugeMetric);


app.UseExceptionHandler(configure =>
{
    configure.Run(async context =>
    {
        IExceptionHandlerPathFeature? exceptionHandlerPathFeature = context.Features.Get<IExceptionHandlerPathFeature>();
        if (exceptionHandlerPathFeature?.Error is not null)
        {
            int statusCode = (int)HttpStatusCode.InternalServerError;
            string errorMessage = exceptionHandlerPathFeature.Error.Message;
            if (exceptionHandlerPathFeature?.Error is DomainException)
            {
                statusCode = (int)HttpStatusCode.BadRequest;
            }
            else if (exceptionHandlerPathFeature?.Error is NotFoundException)
            {
                statusCode = (int)HttpStatusCode.NotFound;
            }
            else
            {
                errorMessage = "Ocorreu um erro inesperado";
            }
            context.Response.StatusCode = statusCode;
            await context.Response.WriteAsJsonAsync(new DefaultResponse(false, errorMessage));
        }
    });
});



app.Run();
// usado para testes de integração
public partial class Program
{
    protected Program() { }
}
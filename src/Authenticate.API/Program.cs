using Duende.IdentityServer.Models;
using Duende.IdentityServer.Stores;

using Authenticate.API.IdentityCustom;
using Authenticate.API.IdentityCustom.Stores;
using Authenticate.API.Repositories;
using Authenticate.API.Setup;

using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);
var configuration = builder.Configuration;

// Add services to the container.

builder.Services.AddControllers();
// Learn more about configuring Swagger/OpenAPI at https://aka.ms/aspnetcore/swashbuckle
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

builder.Services.Configure<ClientStoreDefaultSettings>(configuration.GetSection("ClientStoreDefaultSettings"));


// Configure identity server with in-memory stores, keys, clients and scopes
builder.Services.AddIdentityServer()
    .AddInMemoryApiResources(new List<ApiResource>
            {
                new ApiResource( "todolist.api", "Aplicativos e Sistemas do projeto to do list")
                {
                    Scopes= new[]
                    {
                        "todolist.api"
                    }

                }
            })
    .AddClientStore<ClientStore>()
    .AddInMemoryApiScopes(new List<ApiScope>
            {
                 new ApiScope("todolist.api", "To Do List API"),
                 new ApiScope("introspection", "Introspection")
            })
    .AddResourceOwnerValidator<ResourceOwnerPasswordValidatorCustom>()
   // .AddProfileService<ProfileService>()
    .AddDeveloperSigningCredential();

builder.Services.AddScoped<IDbConnection, SqlConnection>((connection) => new SqlConnection(configuration["ConnectionStrings:SqlServer"]));
builder.Services.AddScoped<IUserRepository, UserRepository>();

var app = builder.Build();

app.UseIdentityServer();

app.MapControllers();
app.Run();

using AutoMapper;
using Grpc.Users.API;
using Grpc.Users.API.Entities;
using Grpc.Users.API.Repositories;
using Grpc.Users.API.Services;
using Microsoft.Data.SqlClient;
using System.Data;

var builder = WebApplication.CreateBuilder(args);

// Add services to the container.
builder.Services.AddGrpc();
var configuration = builder.Configuration;

builder.Services.AddScoped<IDbConnection, SqlConnection>((connection) => new SqlConnection(configuration["ConnectionStrings:SqlServer"]));
builder.Services.AddScoped<IUserRepository, UserRepository>();


var autoMapperConfig = new MapperConfiguration(cfg =>
{
    cfg.CreateMap<UserEntity, SaveUserRequest>().ReverseMap();
});
builder.Services.AddSingleton(autoMapperConfig.CreateMapper());

var app = builder.Build();

// Configure the HTTP request pipeline.
app.MapGrpcService<UserService>();
app.MapGet("/", () => "Communication with gRPC endpoints must be made through a gRPC client. To learn how to create a client, visit: https://go.microsoft.com/fwlink/?linkid=2086909");

app.Run();

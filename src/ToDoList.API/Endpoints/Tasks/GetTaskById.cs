using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Tasks
{
    public class GetTaskById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/tasks/{id}", async (Guid id, ITaskService service) =>
            {
             
                var response = await service.GetByIdAsync(id);
                return Results.Ok(response);
            })
        .WithName("GetTaskById")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Busca a tarefa por id")
        .WithDescription("Buscar tarefa");
        }
    }
}

using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Tasks
{
    public class DeleteTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/tasks/{id}", async (Guid id, ITaskService service) =>
            {                
                var response = await service.DeleteAsync(id);                
                return Results.Ok(response); 
            })
        .WithName("DeleteTask")
        .Produces<DefaultResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Excluir uma lista para organizar as tarefas")
        .WithDescription("Excluir Lista")
        .WithTags("Task");
        }
    }
}

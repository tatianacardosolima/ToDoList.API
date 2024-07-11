using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.TodoList.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Tasks
{
    public class GetTaskByList : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/list/{listid}/tasks", async (Guid listid, IToDoListService service) =>
            {
             
                var response = await service.GetTasksByListAsync(listid);
                return Results.Ok(response);
            })
        .WithName("GetTaskByList")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Busca tarefas por lista")
        .WithDescription("Get tasks by list ")
        .WithTags("Task");
        }
    }
}

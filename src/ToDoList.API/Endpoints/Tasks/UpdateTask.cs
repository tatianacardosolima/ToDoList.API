using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Lists
{
    public class UpdateTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/tasks", async (UpdTaskRequest request, ITaskService service) =>
            {             
                var response = await service.UpdateAsync(request);                
                return Results.Ok(response);
            })
        .WithName("UpdateTask")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Atualiza a lista")
        .WithDescription("Atualizar Lista")
        .WithTags("Task");
        }
    }
}

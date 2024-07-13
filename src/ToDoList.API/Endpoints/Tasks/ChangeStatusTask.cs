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
    public class ChangeStatusTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPatch("/tasks/status", async (UpdChangeStatusRequest request, ITaskService service) =>
            {             
                var response = await service.ChangeStatus(request);
                return Results.Ok(response);
            })
        .WithName("ChangeStatusTask")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Atualiza a lista")
        .WithDescription("Atualizar Lista")
        .WithTags("Task");
        }
    }
}

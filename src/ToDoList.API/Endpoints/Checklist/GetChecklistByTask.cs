using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Checklist
{
    public class GetChecklistByTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("tasks/{id}/checklists", async (Guid id, IChecklistService service) =>
            {
             
                var response = await service.GetByIdAsync(id);
                return Results.Ok(response);
            })
        .WithName("GetChecklistByTask")
        .WithGroupName("checklists")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Busca a lista por id")
        .WithDescription("Atualizar Lista")
        .WithTags("Checklist"); 
        
        }
    }
}

using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Checklist
{
    public class DeleteChecklist : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapDelete("/checklist/{id}", async (Guid id, IChecklistService service) =>
            {                
                var response = await service.DeleteAsync(id);
                return Results.Ok(response); 
            })
        .WithName("DeleteChecklist")        
        .Produces<DefaultResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Excluir uma lista para organizar as tarefas")
        .WithDescription("Excluir Lista");
        }
    }
}

using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Checklist
{
    public class GetChecklistById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/checklists/{id}", async (Guid id, IChecklistService service) =>
            {
             
                var response = await service.GetByIdAsync(id);
                return Results.Ok(response);
            })
        .WithName("GetChecklistById")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Busca a lista por id")
        .WithDescription("Atualizar Lista")
        .WithTags("Checklist"); 
        }
    }
}

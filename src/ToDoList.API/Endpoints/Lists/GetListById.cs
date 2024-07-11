using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Lists
{
    public class GetListById : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/lists/{id}", async (Guid id, IListService service) =>
            {
             
                var response = await service.GetByIdAsync(id);
                return Results.Ok(response);
            })
        .WithName("GetListById")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Busca a lista por id")
        .WithDescription("Atualizar Lista")
        .WithTags("List");
        }
    }
}

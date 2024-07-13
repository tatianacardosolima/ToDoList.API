using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.TodoList.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Lists
{
    public class GetAllList : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapGet("/lists", async (IToDoListService service) =>
            {
             
                var response = await service.GetAll();
                return Results.Ok(response);
            })
        .WithName("GetListById")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .ProducesProblem(StatusCodes.Status404NotFound)
        .WithSummary("Busca a lista por id")
        .WithDescription("Atualizar Lista")
        .WithTags("List");
        }
    }
}

using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Lists
{
    public class UpdateList : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/lists", async (UpdListRequest request, IListService service) =>
            {
             
                var response = await service.UpdateAsync(request);                
                return Results.Ok(response);
            })
        .WithName("UpdateList")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Atualiza a lista")
        .WithDescription("Atualizar Lista");
        }
    }
}

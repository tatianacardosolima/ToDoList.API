using Carter;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Lists
{
    public class CreateList : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/lists", async (NewListRequest request, IListService service) =>
            {
                var newReqest = new IdNameListRequest(request.Name);                

                var response = await service.InsertAsync(newReqest);
                //return Results.Created($"/lists/{response.Data.Id}", response);
                return response;
            })
        .WithName("CreateList")
        .Produces<DefaultResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Criar uma nova lista para organizar as tarefas")
        .WithDescription("Criar Lista");
        }
    }
}

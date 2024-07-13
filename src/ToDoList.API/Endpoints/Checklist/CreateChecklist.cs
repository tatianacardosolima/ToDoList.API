using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Checklist
{
    public class CreateChecklist: ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/checklists", async (NewChecklistRequest request, IChecklistService service) =>
            {
                var newReqest = new UpdChecklistRequest() {
                    TaskId = request.TaskId,
                    Item = request.Item
                };

                var response = await service.InsertAsync(newReqest);
                //return Results.Created($"/lists/{response.Data.Id}", response);
                return response;
            })
        .WithName("CreateChecklist")
        .Produces<DefaultResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Criar uma nova lista para organizar as tarefas")
        .WithDescription("Criar Checklist")
        .WithTags("Checklist"); ;
        }
    }
}

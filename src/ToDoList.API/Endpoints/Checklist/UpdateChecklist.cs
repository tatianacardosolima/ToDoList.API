using Carter;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Checklist
{
    public class UpdateChecklist : ICarterModule
    {
        
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPut("/checklists", async (UpdChecklistRequest request, IChecklistService service) =>
            {
             
                var response = await service.UpdateAsync(request);                
                return Results.Ok(response);
            })
        .WithName("UpdateChecklist")
        .Produces<DefaultResponse>(StatusCodes.Status200OK)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .ProducesProblem(StatusCodes.Status500InternalServerError)
        .WithSummary("Atualiza o checklist")
        .WithDescription("Atualizar Checklist")
        .WithTags("Checklist");
        }
    }
}

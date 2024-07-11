using Carter;
using Microsoft.AspNetCore.Hosting.Server;
using System.Reflection;
using ToDoList.API.Endpoints.Lists;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Shared.Responses;

namespace ToDoList.API.Endpoints.Tasks
{
    public class CreateTask : ICarterModule
    {
        public void AddRoutes(IEndpointRouteBuilder app)
        {
            app.MapPost("/tasks", async (NewTaskRequest request, ITaskService service) =>
            {
                var newReqest = new UpdTaskRequest() { 
                    Description = request.Description,
                    EndAt = request.EndAt,
                    ListId = request.ListId,
                    StartAt = request.StartAt,
                    Status = request.Status,    
                    Title = request.Title,
                    URL = request.URL    
                };   
                

                var response = await service.InsertAsync(newReqest);
                //return Results.Created($"/lists/{response.Data.Id}", response);
                return Results.Created();
            })
        .WithName("CreateTask")
        .Produces<DefaultResponse>(StatusCodes.Status201Created)
        .ProducesProblem(StatusCodes.Status400BadRequest)
        .WithSummary("Criar uma nova lista para organizar as tarefas")
        .WithDescription("Criar Task")
        .WithTags("Task");
        }
    }
}

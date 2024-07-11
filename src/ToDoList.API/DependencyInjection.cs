using Carter;
using Microsoft.EntityFrameworkCore;

using ToDoList.Domain.Lists.Factories;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Services;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Services;
using ToDoList.Domain.Tasks.Factories;
using ToDoList.Infrastructure.Write.Contexts;
using ToDoList.Infrastructure.Write.Repositories;
using ToDoList.Domain.Checklists.Interfaces;
using ToDoList.Domain.Checklists.Factories;
using ToDoList.Domain.Checklists.Services;

namespace ToDoList.API
{
    public static class DependencyInjection
    {
        public static IServiceCollection AddTodoListDependency(this IServiceCollection services, IConfiguration configuration)
        {
            services.AddScoped(serviceProvider =>
            {
                var connectionString = configuration["ConnectionStrings:Postgres"];
                var options = new DbContextOptionsBuilder<TodoListContext>()                    
                    .UseNpgsql(connectionString)
                    .Options;

                var userLoggedInfo = "1"; // Capturar o usuário logado através do Token
                var context = new TodoListContext(options, userLoggedInfo);
                return context;
            });
            services.AddScoped<IChecklistRepository, ChecklistRepository>();
            services.AddScoped<IChecklistFactory, ChecklistFactory>();
            services.AddScoped<IChecklistService, ChecklistService>();

            services.AddScoped<ITaskRepository, TaskRepository>();
            services.AddScoped<ITaskFactory, Domain.Tasks.Factories.TaskFactory>();
            services.AddScoped<ITaskService, TaskService>();

            services.AddScoped<IListRepository, ListRepository>();
            services.AddScoped<IListFactory, ListFactory>();
            services.AddScoped<IListService, ListService>();
            
            services.AddCarter();
            
            //services.AddExceptionHandler<CustomExceptionHandler>();
            //services.AddHealthChecks()
            //    .AddSqlServer(configuration.GetConnectionString("Database")!);

            return services;
        }

        public static WebApplication UseApiServices(this WebApplication app)
        {
            app.MapCarter();

            //app.UseExceptionHandler(options => { });
            //app.UseHealthChecks("/health",
            //    new HealthCheckOptions
            //    {
            //        ResponseWriter = UIResponseWriter.WriteHealthCheckUIResponse
            //    });

            return app;
        }
    }
}

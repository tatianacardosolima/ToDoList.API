using Bogus;
using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Enitities;

namespace ToDoList.Unit.Tests.Entities
{
    public class TaskEntityTest
    {
        private readonly Faker _faker = new("pt_BR");

        [Theory(DisplayName = "Construir um objeto válido do tipo TaskEntity")]        
        [InlineData("Tarefas diárias", "Colocar o lixo na rua!")]
        [InlineData("Tarefas da pós-graduação", "Assistir aula de Azure Functions")]
        [Trait("Action", "ListEntity")]
        public void ListEntity_ValidData_ShouldConstructSuccess(string listName, string taskName)
        {
            var entityList = new ListEntity(listName);
            var entityTask = new TaskEntity(entityList,taskName);

            entityTask.Should().NotBeNull();
            entityTask.Id.Should().NotBeEmpty();
            entityTask.Title.Should().Be(taskName);
            entityTask.IsActive().Should().BeTrue();
            entityTask.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entityTask.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);

        }

        [Theory(DisplayName = "Construir um objeto válido do tipo TaskEntity")]
        [InlineData("Tarefas trabalho", "Reunião de planejamento da nova sprint", "https://saladereunio.com?key=xxxxxxxxxxxxxxxxxxxxxxx")]
        [InlineData("Tarefas da pós-graduação", "Assistir aula de Azure Functions", "https://saladereunio.com?key=yyyyyyyyyyyyyyxxxxxxxxxxxxxxxxxxxxxxxx")]
        [Trait("Action", "ListEntity")]
        public void ListEntity_ValidDataWithURL_ShouldConstructSuccess(string listName, string taskName, string url)
        {
            var entityList = new ListEntity(listName);
            var entityTask = new TaskEntity(entityList, taskName,url);

            DefaultShouldBe(entityTask);            
            entityTask.Title.Should().Be(taskName);
            entityTask.URL.Should().Be(url);            

        }

        [Theory(DisplayName = "Alterar o status para DOING")]
        [InlineData("Tarefas trabalho", "Reunião de planejamento da nova sprint")]        
        [Trait("Action", "UpdateTaskEntity")]
        public void TaskEntity_UpdateName_ShouldChangeDoingStatus(string listName, string taskName )
        {
            var entityList = new ListEntity(listName);
            var entityTask = new TaskEntity(entityList, taskName);
            
            entityTask.GoNextStatus();


            DefaultShouldBe(entityTask);
            entityTask.Title.Should().Be(taskName);
            entityTask.Status.Should().Be(WorkflowStatus.DOING);
            

        }

        [Theory(DisplayName = "Alterar o status para DONE")]
        [InlineData("Tarefas trabalho", "Reunião de planejamento da nova sprint")]
        [Trait("Action", "UpdateTaskEntity")]
        public void TaskEntity_UpdateName_ShouldChangeDoneStatus(string listName, string taskName)
        {
            var entityList = new ListEntity(listName);
            var entityTask = new TaskEntity(entityList, taskName);
            entityTask.GoNextStatus();
            entityTask.GoNextStatus();

            DefaultShouldBe(entityTask);
            entityTask.Title.Should().Be(taskName);
            entityTask.Status.Should().Be(WorkflowStatus.DONE);
            
        }

        private void DefaultShouldBe(TaskEntity entityTask)
        {
            entityTask.Should().NotBeNull();
            entityTask.Id.Should().NotBeEmpty();
            entityTask.IsActive().Should().BeTrue();
            entityTask.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entityTask.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }
    }
}

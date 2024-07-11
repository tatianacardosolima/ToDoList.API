using FluentAssertions;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Checklists.Entities;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Tasks.Enitities;

namespace ToDoList.Unit.Tests.Entities
{
    public class ChecklistEntityTest
    {
        [Theory(DisplayName = "Construir um objeto válido do tipo ChecklistEntity")]
        [InlineData("Tarefas diárias", "Limpar a casa", "varrer a sala")]
        [InlineData("Tarefas diárias", "Limpar a casa", "lavar o banheiro")]
        [InlineData("Tarefas diárias", "Limpar a casa", "trocar a roupa de cama")]
        [Trait("Action", "ListEntity")]
        public void ChecklistEntity_ValidData_ShouldConstructSuccess(string list, string task, string checklist)
        {
            var entityList = new ListEntity(list);
            var entityTask = new TaskEntity(entityList, task);
            var entityChecklist = new ChecklistEntity(entityTask, checklist);

            entityChecklist.Item.Should().Be(checklist);
            entityChecklist.Check.Should().BeFalse();

        }

        [Theory(DisplayName = "Marcar item do checklist como DONE")]
        [InlineData("Tarefas diárias", "Limpar a casa", "varrer a sala")]        
        [InlineData("Tarefas diárias", "Limpar a casa", "trocar a roupa de cama")]
        [Trait("Action", "ListEntity")]
        public void ChecklistEntity_Done_ShouldConstructSuccess(string list, string task, string checklist)
        {
            var entityList = new ListEntity(list);
            var entityTask = new TaskEntity(entityList, task);
            var entityChecklist = new ChecklistEntity(entityTask, checklist);
            entityChecklist.Done();

            entityChecklist.Item.Should().Be(checklist);
            entityChecklist.Check.Should().BeTrue();
        }

        [Theory(DisplayName = "Marcar item do checklist como não feito")]
        [InlineData("Tarefas diárias", "Limpar a casa", "varrer a sala")]
        [InlineData("Tarefas diárias", "Limpar a casa", "trocar a roupa de cama")]
        [Trait("Action", "ListEntity")]
        public void ChecklistEntity_NotDone_ShouldConstructSuccess(string list, string task, string checklist)
        {
            var entityList = new ListEntity(list);
            var entityTask = new TaskEntity(entityList, task);
            var entityChecklist = new ChecklistEntity(entityTask, checklist);
            entityChecklist.Done();
            entityChecklist.NotDone();

            entityChecklist.Item.Should().Be(checklist);
            entityChecklist.Check.Should().BeFalse();
        }

        private void DefaultShouldBe(ChecklistEntity entityChecklist)
        {
            entityChecklist.Should().NotBeNull();
            entityChecklist.Id.Should().NotBeEmpty();
            entityChecklist.IsActive().Should().BeTrue();
            entityChecklist.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entityChecklist.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }
    }
}

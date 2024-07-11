using FluentAssertions;
using ToDoList.Domain.Lists.Entities;

namespace ToDoList.Unit.Tests.Entities
{
    public class ListEntityTest
    {
        [Theory(DisplayName = "Construir um objeto válido do tipo ListEntity")]
        [InlineData("Compras do mês julho")]
        [InlineData("Tarefas diárias")]
        [InlineData("Tarefas da pós-graduação")]        
        [Trait("Action", "ListEntity")]
        public void ListEntity_ValidData_ShouldConstructSuccess(string name)
        {
            var entity = new ListEntity(name);

            entity.Should().NotBeNull();
            entity.Id.Should().NotBeEmpty();
            entity.Name.Should().Be(name);
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);

        }

        [Theory(DisplayName = "Alterar o nome da lista")]
        [InlineData("Compras do mês julho", "Compras no supermercado para o mês de julho")]
        [InlineData("Tarefas diárias", "Tarefas do dia")]
        [InlineData("Tarefas da pós-graduação", "Tarefas da fase 2 da pós-graduação")]
        [Trait("Action", "UpdListEntity")]
        public void ListEntity_UpdateName_ShouldSuccess(string firstName, string secondName)
        {
            var entity = new ListEntity(firstName);

            entity.ChangeName(secondName);

            entity.Should().NotBeNull();
            entity.Id.Should().NotBeEmpty();
            entity.Name.Should().Be(secondName);
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);

        }
    }
}

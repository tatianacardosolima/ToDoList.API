using Bogus;
using FluentAssertions;
using Moq;
using ToDoList.Domain.Lists;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Factories;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using static ToDoList.Shared.Helpers.ErroCodeHelper;
using ToDoList.Shared.Extensions;

namespace ToDoList.Unit.Tests.Factories
{
    public class ListFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateListAsync")]
        public async Task CreateAsync_List_ShouldCreate()
        {
            var request = Get();
            ListFactory factory = new(GetMockRepository(request.Name).Object);
            var entity = await factory.CreateAsync(request);
            
            DefaultShouldBe(entity);
            entity.Name.Should().Be(request.Name);
            

        }

        [Fact]
        [Trait("Action", "CreateListAsync")]
        public async Task CreateAsync_NullName_ShouldError()
        {
            var request = new UpdListRequest();
            
            ListFactory factory = new(GetMockRepository(request.Name).Object);
            ListException exception = await Assert.ThrowsAsync<ListException>(() => factory.CreateAsync(request)); ;
            
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be(ERROR_LIST_NAME_001);

        }

        [Fact]
        [Trait("Action", "CreateListAsync")]
        public async Task CreateAsync_NameMoreThan_ShouldError()
        {
            var request = new UpdListRequest(_faker.Lorem.Sentence(181));

            ListFactory factory = new(GetMockRepository(request.Name).Object);
            ListException exception = await Assert.ThrowsAsync<ListException>(() => factory.CreateAsync(request)); ;

            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be(ERROR_LIST_NAME_002);

        }

        private UpdListRequest Get()
        {
            return new UpdListRequest(_faker.Lorem.Sentence(50).Truncate(180));           
        }
        private Mock<IListRepository> GetMockRepository(string name)
        {
            Mock<IListRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Name == name)).ReturnsAsync(false);
            return repository;
        }

        private void DefaultShouldBe(ListEntity entity)
        {
            entity.Should().NotBeNull();
            entity.Id.Should().NotBeEmpty();
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }
    }
}

using Bogus;
using FluentAssertions;
using Moq;
using ToDoList.Domain.Lists;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Factories;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Domain.Tasks.Enitities;
using ToDoList.Domain.Tasks.Exceptions;
using ToDoList.Domain.Tasks.Interfaces;
using ToDoList.Domain.Tasks.Requests;
using ToDoList.Shared.Extensions;
using static ToDoList.Shared.Helpers.ErroCodeHelper;
namespace ToDoList.Unit.Tests.Factories
{
    public class TaskFactoryTest
    {
        private readonly Faker _faker = new("pt_BR");
        [Fact]
        [Trait("Action", "CreateTaskAsync")]
        public async Task CreateAsync_List_ShouldCreate()
        {
            var request = Get();
            Domain.Tasks.Factories.TaskFactory factory = 
                new(GetMockRepository(request.Title).Object,
                    GetMockListRepository(request.ListId).Object);
            var entity = await factory.CreateAsync(request);

            DefaultShouldBe(entity);
            entity.Title.Should().Be(request.Title);
            entity.Status.Should().Be(request.Status);
            entity.StartAt.Should().Be(request.StartAt);
            entity.EndAt.Should().Be(request.EndAt);
            entity.URL.Should().Be(request.URL);
            

        }

        [Fact]
        [Trait("Action", "CreateListAsync")]
        public async Task CreateAsync_NullTitle_ShouldError()
        {
            var request = Get();
            request.Title = null;
                 
            Domain.Tasks.Factories.TaskFactory factory =
                new(GetMockRepository(request.Title).Object,
                    GetMockListRepository(request.ListId).Object);
            TaskException exception = await Assert.ThrowsAsync<TaskException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be(ERROR_TASK_TITLE_001);

        }

        [Fact]
        [Trait("Action", "CreateListAsync")]
        public async Task CreateAsync_TitleMoreThan120_ShouldError()
        {
            var request = Get();
            request.Title = _faker.Lorem.Sentence(121).Truncate(121);
            Domain.Tasks.Factories.TaskFactory factory =
                new(GetMockRepository(request.Title).Object,
                    GetMockListRepository(request.ListId).Object);
            TaskException exception = await Assert.ThrowsAsync<TaskException>(() => factory.CreateAsync(request));
            exception.Message.Should().NotBeNullOrEmpty();
            exception.Code.Should().Be(ERROR_TASK_TITLE_002);

        }

        private UpdTaskRequest Get()
        {
            return new UpdTaskRequest() {
                ListId = Guid.NewGuid(),
                Title = _faker.Lorem.Sentence().Truncate(120),
                Description = _faker.Lorem.Sentence().Truncate(500),
                URL = _faker.Lorem.Sentence().Truncate(2083),
                StartAt = DateTime.UtcNow.AddDays(2),
                EndAt = DateTime.UtcNow.AddDays(3),
                Status = WorkflowStatus.TODO
            };
        }

        //ITaskRepository repository, IListRepository listRepository
        private Mock<ITaskRepository> GetMockRepository(string title)
        {
            Mock<ITaskRepository> repository = new();
            repository.Setup(c => c.ExistsAsync(x => x.Title == title)).ReturnsAsync(false);
            return repository;
        }
        private Mock<IListRepository> GetMockListRepository(Guid id)
        {
            Mock<IListRepository> repository = new();
            repository.Setup(c => c.GetByIdAsync(id)).ReturnsAsync(new ListEntity());
            return repository;
        }

        private void DefaultShouldBe(TaskEntity entity)
        {
            entity.Should().NotBeNull();
            entity.Id.Should().NotBeEmpty();
            entity.IsActive().Should().BeTrue();
            entity.CreatedAt.Should().BeOnOrBefore(DateTime.UtcNow);
            entity.ModifiedAt.Should().BeOnOrBefore(DateTime.UtcNow);
        }
    }
}

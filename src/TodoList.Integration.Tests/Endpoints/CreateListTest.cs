using Bogus;
using Microsoft.AspNetCore.Mvc.Testing;
using Newtonsoft.Json;
using System.Text;
using System.Text.Json;

using TodoList.Integration.Tests.Helper;
using ToDoList.Domain.Checklists.Requests;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Extensions;
using ToDoList.Shared.Responses;
using static ToDoList.Shared.Helpers.ErroCodeHelper;

namespace TodoList.Integration.Tests.Endpoints
{
    public class CreateListTest: IClassFixture<WebApplicationFactory<Program>>
    {
        private readonly HttpClient _client;
        

        Faker _faker = new Faker();
        public CreateListTest(WebApplicationFactory<Program> factory)
        {
            _client = factory.CreateClient();            
        }


        [Fact(DisplayName = "Validar o cenário principal de cadastro de rota")]
        public async Task Validate_SaveRota_ShuldBeTrue()
        {

            var content = ContentHelper.GetStringContent(Get());
            var response = await _client.PostAsync("/lists", content);

            var result = JsonConvert.DeserializeObject<DefaultResponse>(response.Content.ReadAsStringAsync().Result);
            Assert.NotNull(result);
            Assert.True(result.IsSuccess);

        }
        public NewListRequest Get() 
        {
            return new NewListRequest() { Name = _faker.Lorem.Sentence(120).Truncate(120) };
        }
    }
}

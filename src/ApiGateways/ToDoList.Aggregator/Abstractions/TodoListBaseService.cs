using Common.Shared.Helpers;
using System.Text.Json;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Shared.Responses;

namespace ToDoList.Aggregator.Abstractions
{
    public class TodoListBaseService<TPostRequest, TPutRequest>: IToDoListService<TPostRequest,TPutRequest>
        where TPostRequest : IModel
        where TPutRequest : IModel
    {

        protected readonly HttpClient _client;
        public TodoListBaseService(HttpClient client)
        {
            _client = client ?? throw new ArgumentNullException(nameof(client));
        }

        public async Task<DefaultResponse> PostAsync(TPostRequest request, string uri)
        {
            var response = await _client.PostAsync(uri, JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
        public async Task<DefaultResponse> PutAsync(TPutRequest request, string uri)
        {
            var response = await _client.PutAsync(uri, JsonHelper.GetStringContent(request));
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> GetByIdAsync(Guid id, string uri)
        {
            var response = await _client.GetAsync($"{uri}/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }

        public async Task<DefaultResponse> DeleteByIdAsync(Guid id, string uri)
        {
            var response = await _client.DeleteAsync($"{uri}/{id}");
            return await JsonSerializer.DeserializeAsync<DefaultResponse>(await response.Content.ReadAsStreamAsync());
        }
    }
}

using ToDoList.Shared.Responses;

namespace ToDoList.Aggregator.Interfaces
{
    public interface IToDoListService<TPostRequest, TPutRequest>
        where TPostRequest : IModel
        where TPutRequest : IModel
    {
        Task<DefaultResponse> PostAsync(TPostRequest request, string uri);
        Task<DefaultResponse> PutAsync(TPutRequest request, string uri);
        Task<DefaultResponse> GetByIdAsync(Guid id, string uri);
        Task<DefaultResponse> DeleteByIdAsync(Guid id, string uri);

    }
}

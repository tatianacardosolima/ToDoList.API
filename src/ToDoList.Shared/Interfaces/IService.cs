using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Responses;

namespace ToDoList.Shared.Interfaces
{
    public interface IService<TEntity, TRequest,
                              TResponse>
        where TEntity : EntityBase
        where TRequest : IRequest
        where TResponse : ResponseBase
    {
        Task<DefaultResponse> InsertAsync(TRequest request);
        Task<DefaultResponse> DeleteAsync(Guid uniqueId);
        Task<DefaultResponse> UpdateAsync(TRequest request);
        Task<DefaultResponse> GetByIdAsync(Guid id);
    }
}

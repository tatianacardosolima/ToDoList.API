using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Shared.Abstractions;

namespace ToDoList.Shared.Interfaces
{
    public interface IFactory<TRequest, TEntity> 
            where TRequest: IRequest 
            where TEntity : EntityBase

    {
        Task<TEntity> CreateAsync(TRequest request);
    }
}

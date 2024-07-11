using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Domain.Lists.Entities;
using ToDoList.Domain.Lists.Interfaces;
using ToDoList.Domain.Lists.Requests;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Exceptions;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Domain.Lists.Factories
{
    public interface IListFactory : IFactory<IdNameListRequest,ListEntity>
    {
        Task<ListEntity> CreateAsync(IdNameListRequest request);
    }
    public class ListFactory : IListFactory
    {
        private readonly IListRepository _listRepository;

        public ListFactory(IListRepository listRepository)
        {
            _listRepository = listRepository;
        }
        public async Task<ListEntity> CreateAsync(IdNameListRequest request)
        {
            var entity = new ListEntity(request.Name);
            var exist = await _listRepository.ExistsAsync(x => x.Name.Equals(request.Name));
            DomainException.ThrowWhen(exist, "O nome da lista já existe no sistema");
            return entity;
        }
    }
}

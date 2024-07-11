using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;
using ToDoList.Infrastructure.Write.Contexts;
using ToDoList.Shared.Abstractions;
using ToDoList.Shared.Interfaces;

namespace ToDoList.Infrastructure.Write.Abstractions
{
    public class RepositoryBase<T, TId> : IRepository<T, Guid>
        where T : EntityBase
        where TId : struct
    {
        private readonly TodoListContext _context;

        public RepositoryBase(TodoListContext context)
        {
            _context = context;
        }
        public void Delete(T entity)
        {
            _context.Remove(entity);
        }

        public Task<bool> ExistsAsync(Expression<Func<T, bool>> expression)
        {
            return _context.Set<T>().AnyAsync(expression);
        }

        public async Task<T> GetByIdAsync(Guid id)
        {
            var entity = await _context.Set<T>()                                   
                                   .Where(x => x.Id.Equals(id))
                                   .ToListAsync();

            return entity.FirstOrDefault();
        }

        public async Task InsertAsync(T entity)
        {
            await _context.Set<T>()
               .AddAsync(entity);
        }

        public Task SaveChangesAsync()
        {
            return _context.SaveChangesAsync();
        }

        public void Update(T entity)
        {
            _context.Set<T>()
                .UpdateRange(entity);
        }
    }
}

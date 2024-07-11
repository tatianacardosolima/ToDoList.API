using Dapper;
using System.Data;
using ToDoList.Domain.TodoList.Interfaces;
using ToDoList.Domain.TodoList.Queries;

namespace TodoList.Infrastructure.Read.Providers
{
    public class TodoListProvider : ITodoListProvider
    {
        private readonly IDbConnection _connection;
        public TodoListProvider(IDbConnection connection)
        {
            _connection = connection;
        }

        public async Task<List<ListQuery>> GetAllListAsync()
        {         

            var sql = @"
                        SELECT 
                            l.""Id"" AS ListId, l.""Name"", 
                            t.""Id"" AS TaskId, t.""Title"", 
                            c.""Id"" AS ChecklistId, c.""Item"", c.""Check""
                        FROM public.""List"" AS l
                        LEFT JOIN public.""Task"" AS t ON t.""ListId"" = l.""Id""
                        LEFT JOIN public.""Checklist"" AS c ON c.""TaskId"" = t.""Id"";";            

            var result = (await _connection.QueryAsync<TodoListQuery>(sql)).ToList();
            var list = result.DistinctBy(x => x.ListId).Select(x => new ListQuery()
            {
                Id = x.ListId, Name = x.Name
            }).ToList();

            list.ForEach(x => x.Tasks.AddRange(
                result.Where(y => y.ListId == x.Id && y.TaskId != Guid.Empty).DistinctBy(y=> y.TaskId)
                .Select(y => new TaskQuery() { Id = y.TaskId, Title = y.Title,
                Checklists = result.Where(k => k.TaskId == y.TaskId && k.ChecklistId != Guid.Empty).Select(k => new ChecklistQuery() 
                    { 
                        Item = k.Item,
                        Id = k.ChecklistId,
                        Check = k.Check

                    }).ToList()
                })));

            
            return list;
        }

        public async Task<List<TaskQuery>> GetAllTaskByListAsync(Guid listid)
        {
            

            var sql = @"
                        SELECT 
                            l.""Id"" AS ListId, l.""Name"", 
                            t.""Id"" AS TaskId, t.""Title"", 
                            c.""Id"" AS ChecklistId, c.""Item"", c.""Check""
                        FROM public.""Task"" l
                        where ListId = @listid";

            return (await _connection.QueryAsync<TaskQuery>(sql, new { listid = listid })).ToList();            
            
        }
    }
}

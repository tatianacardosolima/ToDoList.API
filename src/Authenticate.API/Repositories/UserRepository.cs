using Authenticate.API.Queries;
using Dapper;
using System.Data;

namespace Authenticate.API.Repositories
{
    public interface IUserRepository
    {
        Task<UserQuery> GetByEmailAsync(string email);
        Task<UserQuery> GetByIdAsync(Guid id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;

        }
        public async Task<UserQuery> GetByEmailAsync(string email)
        {
            var commandSql = "Select Id, name, email, password from Users where email = @email";
            var user = await _connection.QuerySingleOrDefaultAsync<UserQuery>(commandSql, 
                        new { email = email});
            return user;
        }

        public async Task<UserQuery> GetByIdAsync(Guid id)
        {
            var commandSql = "Select Id, name, email, password from Users where id = @id";
            var user = await _connection.QuerySingleOrDefaultAsync<UserQuery>(commandSql,
                        new { id = id});
            return user;
        }
    }
}

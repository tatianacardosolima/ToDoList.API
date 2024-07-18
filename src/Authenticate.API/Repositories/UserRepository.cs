using Authenticate.API.Queries;
using Dapper;
using System.Data;

namespace Authenticate.API.Repositories
{
    public interface IUserRepository
    {
        Task<UserQuery> GetByEmailAsync(string email);
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
    }
}

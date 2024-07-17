using Grpc.Users.API.Entities;
using Dapper;
using Dapper.Contrib.Extensions;
using System.Data;
using Microsoft.AspNetCore.Http.HttpResults;
namespace Grpc.Users.API.Repositories
{
    public interface IUserRepository
    {
        Task InsertAsync(UserEntity entity);
        Task UpdateAsync(UserEntity entity);
        Task DeleteAsync(UserEntity entity);
        Task<UserEntity> GetByIdAsync(Guid id);
    }
    public class UserRepository : IUserRepository
    {
        private readonly IDbConnection _connection;

        public UserRepository(IDbConnection connection)
        {
            _connection = connection;

        }

        public async Task DeleteAsync(UserEntity entity)
        {
            await _connection.DeleteAsync<UserEntity>(entity);
        }

        public async Task<UserEntity> GetByIdAsync(Guid id)
        {
            var commandSql = "Select * from User where Id = @Id";
            return await _connection.QuerySingleAsync<UserEntity>(commandSql);
        }

        public async Task InsertAsync(UserEntity entity)
        {
            await _connection.ExecuteAsync(@"Insert into Users (Id, Name, Email, Password, CreateAt)
                    values (@Id, @Name, @Email, @Password, @CreateAt)"
            ,
                    new {
                        Id = entity.Id, 
                        Name = entity.Name, 
                        Email = entity.Email,
                        Password = entity.Password, 
                        CreateAt = entity.CreateAt
                    });
        }

        public async Task UpdateAsync(UserEntity entity)
        {
            await _connection.UpdateAsync<UserEntity>(entity);
        }
    }
}

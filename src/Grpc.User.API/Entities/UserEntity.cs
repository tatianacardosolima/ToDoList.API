using Dapper.Contrib.Extensions;

namespace Grpc.Users.API.Entities
{
    [Table("Users")]
    public class UserEntity
    {
        public UserEntity()
        {
            Id = Guid.NewGuid();
            CreateAt = DateTime.Now;
        }
        public Guid Id { get; set; }
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
        public DateTime CreateAt { get; set; }
    }
}
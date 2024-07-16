using Grpc.Core;

namespace Grpc.Users.API.Services
{
    public class UserService  : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        public UserService(ILogger<UserService> logger)
        {
            _logger = logger;
        }

        public override Task<SaveUserResponse> Save(SaveUserRequest request, ServerCallContext context)
        {
            return Task.FromResult(new SaveUserResponse
            {
                Id = "1",
                Message = "Usuário salvo com sucesso",
                Success = true
            });
        }

        public override Task<GetUserByIdResponse> GetById(GetUserByIdRequest request, ServerCallContext context)
        {
            return Task.FromResult(new GetUserByIdResponse
            {
                Email = "tatiana@lima.com",
                Name = "tatiana lima"
            });
        }
    }
}

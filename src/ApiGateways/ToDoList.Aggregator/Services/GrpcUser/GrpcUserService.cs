using Grpc.Users.API;
using static Grpc.Users.API.User;

namespace ToDoList.Aggregator.Services.GrpcUser
{
    public class GrpcUserService
    {
        private readonly User.UserClient _userGrpcClient;

        public GrpcUserService(User.UserClient userGrpcClient)
        {
            _userGrpcClient = userGrpcClient  ?? throw new ArgumentNullException(nameof(userGrpcClient));
        }

        public  Task<SaveUserResponse> Save(SaveUserRequest request)
        {
            return Task.FromResult(_userGrpcClient.Save(request));
        }

        public Task<GetUserByIdResponse> GetById(GetUserByIdRequest request)
        {
            return Task.FromResult(_userGrpcClient.GetById(request));
        }
    }
}

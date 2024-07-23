using AutoMapper;
using Common.Password;
using Grpc.Core;
using Grpc.Users.API.Entities;
using Grpc.Users.API.Repositories;

namespace Grpc.Users.API.Services
{
    public class UserService  : User.UserBase
    {
        private readonly ILogger<UserService> _logger;
        private readonly IUserRepository _repository;
        private readonly IMapper _mapper;

        public UserService(ILogger<UserService> logger, IUserRepository repository, IMapper mapper)
        {
            _logger = logger;
            _repository = repository;
            _mapper = mapper;
        }

        public override async Task<SaveUserResponse> Save(SaveUserRequest request, ServerCallContext context)
        {
            var passwordService = new PasswordService();
            request.Password = passwordService.HashPassword(request.Email, request.Password);

            var entity = _mapper.Map<UserEntity>(request);
            //entity.Id = Guid.NewGuid();
            //entity.CreateAt = DateTime.Now;
            await _repository.InsertAsync(entity);
            return new SaveUserResponse()
            {
                Success = true,
                Message = "Usuário inserido com sucesso",
                Id = entity.Id.ToString()
            };
        }

        public override async Task<GetUserByIdResponse> GetById(GetUserByIdRequest request, ServerCallContext context)
        {
            var entity = await _repository.GetByIdAsync(Guid.Parse(request.Id));
            return new GetUserByIdResponse
            {
                Email = entity.Email,
                Name = entity.Name,
                Id = entity.Id.ToString()
            };
        }
    }
}

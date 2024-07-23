using Grpc.Users.API;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using ToDoList.Aggregator.Interfaces;
using ToDoList.Aggregator.Services.GrpcUser;

namespace ToDoList.Aggregator.Controllers.User
{
    [ApiController]
    [Route("users")]
    public class UserController : ControllerBase        


    {
        private readonly GrpcUserService _service;

        public UserController(GrpcUserService service)
        {
            _service = service;
        }

        [HttpPost/*, Authorize*/]
        public IActionResult PostAsync(SaveUserRequest request)
        {
            return Ok(_service.Save(request));
        }       

        [HttpGet("{id}"), Authorize]
        public IActionResult GetByIdAsync(Guid id)
        {
            return Ok(_service.GetById(new GetUserByIdRequest() { Id = id.ToString() }));
        }
        
    }
}

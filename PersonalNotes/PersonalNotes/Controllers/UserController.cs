using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using PersonalNotes.Interfaces.Services.Request.Users;
using PersonalNotes.Interfaces.Services.UseCase.Users;

namespace PersonalNotes.Controllers
{
    [ApiController]
    [AllowAnonymous]
    [Route("api/v1/user")]
    public class UserController : ControllerBase
    {
        private readonly IUseCaseCreateUser _useCaseCreateUser;
        private readonly IUseCaseAuthenticateUser _useCaseAuthenticateUser;

        public UserController(IUseCaseCreateUser useCaseCreateUser, IUseCaseAuthenticateUser useCaseAuthenticateUser)
        {
            _useCaseCreateUser = useCaseCreateUser;
            _useCaseAuthenticateUser = useCaseAuthenticateUser;
        }

        [HttpPost]
        public IActionResult CreateUser([FromBody] CreateUserRequest request)
        {
            return _useCaseCreateUser.Execute(request);
        }

        [HttpPost("authenticate")]
        public IActionResult AuthenticateUser([FromBody] AuthenticateUserRequest request)
        {
            return _useCaseAuthenticateUser.Execute(request);
        }
    }
}
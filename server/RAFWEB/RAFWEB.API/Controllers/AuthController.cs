using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using RAFWEB.Domain.Commands.Request.User;
using RAFWEB.Domain.Commands.Response.Service;
using RAFWEB.Domain.Services;
using RAFWEB.Domain.Services.Interfaces;

namespace RAFWEB.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthController : ControllerBase
    {
        private readonly IAuthService _authService;

        public AuthController(IAuthService authService)
        {
            _authService = authService;
        }

        [HttpPost("SignUp")]
        public async Task<ServiceResponse<SignUpUserRequest>> SignUp([FromBody] SignUpUserRequest signUpUser)
        {
            var result = await _authService.SignUp(signUpUser);
            return new ServiceResponse<SignUpUserRequest>(result.Error);
        }

        [HttpPost("SignIn")]
        public async Task<ServiceResponse<SignInUserRequest>> SignIn([FromBody] SignInUserRequest signUpUser)
        {
            var result = await _authService.SignIn(signUpUser);
            return new ServiceResponse<SignInUserRequest>(result.Error);
        }




    }
}

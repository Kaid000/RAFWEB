using RAFWEB.Domain.Commands.Request.User;
using RAFWEB.Domain.Commands.Response.Service;

namespace RAFWEB.Domain.Services.Interfaces
{
    public interface IAuthService
    {
        Task<ServiceResponse<SignUpUserRequest>> SignUp(SignUpUserRequest signUpUser);

        Task<ServiceResponse> CheckUniqueEmail(string email);

        Task<ServiceResponse> CheckUniqueUsername(string UserName);

        Task<ServiceResponse<SignInUserRequest>> SignIn(SignInUserRequest signInUser);
    }
}

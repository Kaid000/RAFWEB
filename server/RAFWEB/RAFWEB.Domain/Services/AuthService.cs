using Microsoft.AspNetCore.Identity;
using RAFWEB.Data.Models;
using RAFWEB.Domain.Commands.Request.User;
using RAFWEB.Domain.Commands.Response.Service;
using RAFWEB.Domain.Repositories.Users.Interfaces;
using RAFWEB.Domain.Services.Interfaces;

namespace RAFWEB.Domain.Services
{
    public class AuthService : IAuthService
    {
        private readonly IUserRepository   _userRepository;
        private readonly UserManager<User> _userManager;
        private readonly SignInManager<User> _SignIn;
        public AuthService(IUserRepository userRepository, UserManager<User> userManager, SignInManager<User> signIn)
        {
            _userRepository = userRepository;
            _userManager = userManager;
            _SignIn = signIn;
        }

        public async Task<ServiceResponse<SignUpUserRequest>> SignUp(SignUpUserRequest signUpUser)
        {
            var user = new User { Email = signUpUser.Email, UserName = signUpUser.UserName, };
            var emailUnique = await CheckUniqueEmail(user.Email);
            if (!emailUnique.Success) return new ServiceResponse<SignUpUserRequest>(emailUnique);

            var userNameUnique = await CheckUniqueUsername(user.UserName);
            if (!userNameUnique.Success) return new ServiceResponse<SignUpUserRequest>(userNameUnique);

            var identityResult = await _userManager.CreateAsync(user, signUpUser.Password);
            return !identityResult.Succeeded
                ? new ServiceResponse<SignUpUserRequest>("Password badValidation")
                : new ServiceResponse<SignUpUserRequest>(signUpUser);
        }

        public Task<ServiceResponse> CheckUniqueEmail(string email)
        {
            var isEmailUnique = !_userRepository.GetAllUsers().Where(x => x.Email == email).Any();

            return isEmailUnique ? Task.FromResult(new ServiceResponse()) : Task.FromResult(new ServiceResponse("Email not Unique"));

        }

        public Task<ServiceResponse> CheckUniqueUsername(string UserName)
        {
            var isEmailUnique = !_userRepository.GetAllUsers().Where(x => x.UserName == UserName).Any();

            return isEmailUnique ? Task.FromResult(new ServiceResponse()) : Task.FromResult(new ServiceResponse("Username not Unique"));
        }

        public async Task<ServiceResponse<SignInUserRequest>> SignIn(SignInUserRequest signInUser)
        {
                var result = await _SignIn.PasswordSignInAsync(signInUser.Username, signInUser.Password, false, false);
                
                return result.Succeeded ? new ServiceResponse<SignInUserRequest>(signInUser) : new ServiceResponse<SignInUserRequest>("Incorrect Password");
           
        }
    }
}

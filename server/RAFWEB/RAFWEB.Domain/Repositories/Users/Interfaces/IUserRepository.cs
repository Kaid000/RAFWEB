using RAFWEB.Data.Models;
using RAFWEB.Domain.Commands.Request.User;


namespace RAFWEB.Domain.Repositories.Users.Interfaces
{
    public interface IUserRepository
    {
        List<User> GetAllUsers();

        Task<User> GetUserByUsername(string Username);

        Task<User> CreateUserAsync(User user);

        Task<User> UpdateUserAsync(User user);

        Task<User> DeleteUserAsync(User user);
    }
}


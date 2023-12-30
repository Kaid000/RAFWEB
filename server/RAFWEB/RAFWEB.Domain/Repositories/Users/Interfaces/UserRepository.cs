using Microsoft.EntityFrameworkCore;
using RAFWEB.Core;
using RAFWEB.Data.Models;

namespace RAFWEB.Domain.Repositories.Users.Interfaces
{
    public class UserRepository : IUserRepository
    {
        private readonly ApplicationContext _db;
        private readonly DbSet<User> _users;
        public UserRepository(ApplicationContext db)
        {
            _db = db;
            _users = _db.Users;

        }



        public async Task<User> CreateUserAsync(User user)
        {
            await _users.AddAsync(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public async Task<User> DeleteUserAsync(User user)
        {
            _users.Remove(user);
            await _db.SaveChangesAsync();
            return user;
        }

        public List<User> GetAllUsers()
        {
            return _db.Users.ToList();
        }

        public async Task<User> GetUserByUsername(string Username)
        {
            return await _db.Users.FirstOrDefaultAsync(x => x.UserName == Username);
        }

        public async Task<User> UpdateUserAsync(User user)
        {
            _db.Update(user);
            await _db.SaveChangesAsync();
            return user;
        }
    }
}

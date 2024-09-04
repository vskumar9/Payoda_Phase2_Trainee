using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repository;

namespace SocialMediaPlatform.Services
{
    public class UserService : IUserRepository
    {
        private readonly SocialMediaPlatformDbContext _context;
        public UserService(SocialMediaPlatformDbContext context)
        {
            _context = context;
        }

        public void AddUser(User user)
        {
            _context.Users.Add(user);
            _context.SaveChanges();
        }

        public void DeleteUser(User user)
        {
            _context.Remove(user);
            _context.SaveChanges();
        }

        public IEnumerable<User>? GetAllUsers()
        {
            return _context.Users.Include(a => a.Posts).ToList();
        }

        public User? GetUserById(int id)
        {
            return _context.Users.Include(p => p.Posts).FirstOrDefault(i => i.uId == id);
        }

        public void UpdateUser(User user)
        {
            _context.Users.Update(user);
            _context.SaveChanges();
        }
    }
}

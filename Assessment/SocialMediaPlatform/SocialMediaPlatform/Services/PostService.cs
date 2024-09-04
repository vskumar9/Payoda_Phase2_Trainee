using Microsoft.EntityFrameworkCore;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repository;

namespace SocialMediaPlatform.Services
{
    public class PostService : IPostRepository
    {
        private readonly SocialMediaPlatformDbContext _context;
        public PostService(SocialMediaPlatformDbContext context)
        {
            _context = context;
        }

        public void AddPost(Post post)
        {
            _context.Posts.Add(post);
            _context.SaveChanges();
        }

        public void DeletePost(Post post)
        {
            _context.Posts.Remove(post); 
            _context.SaveChanges();
        }

        public IEnumerable<Post> GetAllPosts()
        {
            return _context.Posts.Include(u => u.User).ToList();
        }

        public Post? GetPostById(int id)
        {
            return _context.Posts.Include(u => u.User).FirstOrDefault(p => p.PostId == id);
        }

        public IEnumerable<Post> GetPostsByUserId(int userId)
        {
            return _context.Posts
                           .Where(p => p.UserId == userId)
                           .ToList();
        }


        public void UpdatePost(Post post)
        {
            _context.Posts.Update(post);
            _context.SaveChanges();
        }
    }
}

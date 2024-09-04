using SocialMediaPlatform.Models;

namespace SocialMediaPlatform.Repository
{
    public interface IPostRepository
    {
        IEnumerable<Post> GetAllPosts();
        Post? GetPostById(int id);
        void AddPost(Post post);
        void UpdatePost(Post post);
        void DeletePost(Post post);
        IEnumerable<Post> GetPostsByUserId(int userId);
    }
}

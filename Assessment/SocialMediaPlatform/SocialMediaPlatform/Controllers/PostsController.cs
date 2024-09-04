using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repository;

namespace SocialMediaPlatform.Controllers
{
    public class PostsController : Controller
    {
        private readonly IPostRepository _post;
        private readonly IUserRepository _user;
        public PostsController(IPostRepository post, IUserRepository user)
        {
            _post = post;
            _user = user;
        }

        // GET: PostsController
        public ActionResult Index()
        {
            return View(_post.GetAllPosts());
        }

        // GET: PostsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_post.GetPostById(id));
        }

        // GET: PostsController/Create
        public ActionResult Create()
        {
            var users = _user.GetAllUsers(); 
            ViewBag.UserId = new SelectList(users, "uId", "Username");
            return View();
        }

        // POST: PostsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Post post)
        {
            try
            {
               
                _post.AddPost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.UserId = new SelectList(_user.GetAllUsers(), "uId", "Username");
            return View(_post.GetPostById(id));
        }

        // POST: PostsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Post post)
        {
            try
            {
                _post.UpdatePost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: PostsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_post.GetPostById(id));
        }

        // POST: PostsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Post post)
        {
            try
            {
                _post.DeletePost(post);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

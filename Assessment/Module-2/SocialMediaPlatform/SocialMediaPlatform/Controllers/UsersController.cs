using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using SocialMediaPlatform.Models;
using SocialMediaPlatform.Repository;

namespace SocialMediaPlatform.Controllers
{
    public class UsersController : Controller
    {
        private readonly IUserRepository _user;
        public UsersController(IUserRepository user)
        {
            _user = user;
        }

        // GET: UsersController
        public ActionResult Index()
        {
            return View(_user.GetAllUsers());
        }

        // GET: UsersController/Details/5
        public ActionResult Details(int id)
        {
            return View(_user.GetUserById(id));
        }

        // GET: UsersController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: UsersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(User user)
        {
            try
            {
                _user.AddUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_user.GetUserById(id));
        }

        // POST: UsersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, User user)
        {
            try
            {
                _user.UpdateUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: UsersController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_user.GetUserById(id));
        }

        // POST: UsersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, User user)
        {
            try
            {
                _user.DeleteUser(user);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

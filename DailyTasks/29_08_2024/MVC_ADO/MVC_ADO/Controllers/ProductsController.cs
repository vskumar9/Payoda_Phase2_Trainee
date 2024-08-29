using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using MVC_ADO.DataAccess;
using MVC_ADO.Models;

namespace MVC_ADO.Controllers
{
    public class ProductsController : Controller
    {
        ProductDataAccess productDataAccess = new ProductDataAccess();

        // GET: ProductsController
        public IActionResult Index()
        {
            var product = productDataAccess.Fetch;
            return View(product);
        }

        // GET: ProductsController/Details/5
        public ActionResult Details(int id)
        {
            var product = productDataAccess.GetProductById(id);
            return View(product);
        }

        // GET: ProductsController/Create
        public ActionResult Create()
        {

            return View();
        }

        // POST: ProductsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Product collection)
        {
            try
            {
                Product product = productDataAccess.Insert(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Edit/5
        public ActionResult Edit(int id)
        {
            var product = productDataAccess.GetProductById(id);
            return View(product);
        }

        // POST: ProductsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Product collection)
        {
            try
            {
                //var product = productDataAccess.GetProductById(id);
                productDataAccess.Update(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: ProductsController/Delete/5
        public ActionResult Delete(int id)
        {
            var product = productDataAccess.GetProductById(id);
            return View(product);
        }

        // POST: ProductsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                productDataAccess.Delete(id);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

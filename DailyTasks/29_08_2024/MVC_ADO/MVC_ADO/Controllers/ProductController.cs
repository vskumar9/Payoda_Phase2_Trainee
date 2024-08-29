using Microsoft.AspNetCore.Mvc;
using MVC_ADO.DataAccess;

namespace MVC_ADO.Controllers
{
    public class ProductController : Controller
    {

        ProductDataAccess productDataAccess = new ProductDataAccess();
        public IActionResult Index()
        {
            var product = productDataAccess.Fetch;
            return View(product);
        }
    }
}

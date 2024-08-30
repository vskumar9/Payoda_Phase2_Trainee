using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using MVCEFDBFirst.Models;

namespace MVCEFDBFirst.Controllers
{
    public class OrdersController : Controller
    {
        private MvcKumarContext _context;

        public OrdersController(MvcKumarContext context)
        {
            _context = context;
        }
        // GET: OrdersController
        public ActionResult Index()
        {
            return View(_context.Orders.Include(o => o.Cust));
        }

        // GET: OrdersController/Details/5
        public ActionResult Details(int id)
        {
            var order = _context.Orders.Include(o => o.Cust).FirstOrDefault(o => o.OrderId == id);
            return View(order);
        }

        // GET: OrdersController/Create
        public ActionResult Create()
        {
            ViewBag.CustId = new SelectList(_context.Customers, "CustId", "CustId");
            return View();
        }

        // POST: OrdersController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Order collection)
        {
            try
            {
                _context.Add(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Edit/5
        public ActionResult Edit(int id)
        {
            var order = _context.Orders.Find(id);
            ViewBag.CustId = new SelectList(_context.Customers, "CustId", "CustId");
            return View(order);
        }

        // POST: OrdersController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Order collection)
        {
            try
            {
                _context.Update(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: OrdersController/Delete/5
        public ActionResult Delete(int id)
        {
            var order = _context.Orders.Include(o => o.Cust).FirstOrDefault(o => o.OrderId == id);
            return View(order);
        }

        // POST: OrdersController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Order collection)
        {
            try
            {
                _context.Orders.Remove(collection);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

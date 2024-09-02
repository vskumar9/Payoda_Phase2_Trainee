using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using HotelRepoPatternAssignment.Service;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelRepoPatternAssignment.Controllers
{
    public class HotelController : Controller
    {
        private readonly IHotel _hotel;

        public HotelController(IHotel hotel)
        {
            _hotel = hotel;
        }



        // GET: HotelsController
        public ActionResult Index()
        {
            return View(_hotel.GetHotels());
        }

        // GET: HotelsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // GET: HotelsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: HotelsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Hotel collection)
        {
            try
            {
                _hotel.AddHotel(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Edit/5
        public ActionResult Edit(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // POST: HotelsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Hotel collection)
        {
            try
            {
                _hotel.UpdateHotel(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: HotelsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_hotel.GetHotelById(id));
        }

        // POST: HotelsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Hotel collection)
        {
            try
            {
                _hotel.DeleteHotel(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

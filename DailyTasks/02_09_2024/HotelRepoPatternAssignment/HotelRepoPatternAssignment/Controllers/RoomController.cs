using HotelRepoPatternAssignment.Models;
using HotelRepoPatternAssignment.Repository;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;

namespace HotelRepoPatternAssignment.Controllers
{
    public class RoomController : Controller
    {
        private readonly IRoom _room;
        private readonly IHotel _hotel;

        public RoomController(IRoom room, IHotel hotel)
        {
            _room = room;
            _hotel = hotel;
        }


        // GET: RoomsController
        public ActionResult Index()
        {
            return View(_room.GetRooms());
        }

        // GET: RoomsController/Details/5
        public ActionResult Details(int id)
        {
            return View(_room.GetRoomById(id));
        }

        // GET: RoomsController/Create
        public ActionResult Create()
        {
            ViewBag.HotelId = new SelectList(_hotel.GetHotels(), "HotelId", "HotelId");
            return View();
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room collection)
        {
            try
            {
                ViewBag.HotelId = new SelectList(_hotel.GetHotels(), "HotelId", "HotelId");
                _room.AddRoom(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomsController/Edit/5
        public ActionResult Edit(int id)
        {
            ViewBag.HotelId = new SelectList(_hotel.GetHotels(), "HotelId", "HotelId");
            return View(_room.GetRoomById(id));
        }

        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room collection)
        {
            try
            {
                ViewBag.HotelId = new SelectList(_hotel.GetHotels(), "HotelId", "HotelId");
                _room.UpdateRoom(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomsController/Delete/5
        public ActionResult Delete(int id)
        {
            return View(_room.GetRoomById(id));
        }

        // POST: RoomsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Room collection)
        {
            try
            {
                _room.DeleteRoom(collection);
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

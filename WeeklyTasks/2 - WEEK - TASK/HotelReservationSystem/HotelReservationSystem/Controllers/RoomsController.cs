using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace HotelReservationSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly HotelDBContext _context;

        public RoomsController(HotelDBContext context)
        {
            _context = context;
        }

        // GET: RoomsController
        public ActionResult Index()
        {
            return View(_context.Rooms.ToList());
        }

        // GET: RoomsController/Details/5
        public ActionResult Details(int? id)
        {
            if(id == null || id == 0)
            {
                return NotFound();
            }
            var room = _context.Rooms.FirstOrDefault(o => o.RoomId == id);
            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // GET: RoomsController/Create
        public ActionResult Create()
        {
            return View();
        }

        // POST: RoomsController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Create(Room collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Rooms.Add(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return View(collection);
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomsController/Edit/5
        public ActionResult Edit(int id)
        {
            if(id == null)
            {
                return NotFound();
            }
            var room = _context.Rooms.Find(id);
            if(room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // POST: RoomsController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, Room collection)
        {
            try
            {
                if (ModelState.IsValid)
                {
                    _context.Rooms.Update(collection);
                    _context.SaveChanges();
                    return RedirectToAction(nameof(Index));
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: RoomsController/Delete/5
        public ActionResult Delete(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }
            var room = _context.Rooms.FirstOrDefault(o => o.RoomId == id);
            if (room == null)
            {
                return RedirectToAction(nameof(Index));
            }
            return View(room);
        }

        // POST: RoomsController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, Room collection)
        {
            try
            {
                var room = _context.Rooms.Find(id);
                if (room != null)
                {
                    _context.Rooms.Remove(room);
                }
                
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

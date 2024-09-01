using HotelReservationSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;

namespace HotelReservationSystem.Controllers
{
    public class ReservationsController : Controller
    {
        private readonly HotelDBContext _Context;

        public ReservationsController(HotelDBContext context)
        {
            _Context = context;
        }

        public IActionResult Index()
        {
            return View(_Context.Reservations.Include(c => c.Customer).Include(r => r.Room).ToList());
        }

        public IActionResult Details(int? id)
        {
            if (id == null || id == 0)
            {
                return NotFound();
            }

            var reservation = _Context.Reservations
                .Include(c => c.Customer)
                .Include(r => r.Room)
                .FirstOrDefault(r => r.ReservationId == id);

            if (reservation == null)
            {
                return RedirectToAction(nameof(Index));
            }

            return View(reservation);
        }

        [HttpGet]
        public IActionResult Create()
        {
            ViewBag.RoomId = new SelectList(_Context.Rooms.Where(r => r.IsAvailable == true), "RoomId", "RoomNumber");
            ViewBag.CustomerId = new SelectList(_Context.Customers, "CustomerId", "CustomerId");
            return View();
        }

        [HttpPost]
        public IActionResult Create(Reservation reservation)
        {
            if (ModelState.IsValid)
            {
                var room = _Context.Rooms.Find(reservation.RoomId);
                if (room == null || !room.IsAvailable)
                {
                    ModelState.AddModelError("", "Selected room is not available.");
                    ViewBag.CustomerId = new SelectList(_Context.Customers, "CustomerId", "CustomerId");
                    ViewBag.RoomId = new SelectList(
                        _Context.Rooms.Where(r => r.IsAvailable)
                                      .Select(r => new { r.RoomId, r.RoomNumber }),
                        "RoomId",
                        "RoomNumber");
                    return View(reservation);
                }

                _Context.Reservations.Add(reservation);

                room.IsAvailable = false;
                _Context.Rooms.Update(room);

                _Context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }

            ViewBag.CustomerId = new SelectList(_Context.Customers, "CustomerId", "CustomerId");
            ViewBag.RoomId = new SelectList(
                _Context.Rooms.Where(r => r.IsAvailable)
                              .Select(r => new { r.RoomId, r.RoomNumber }),
                "RoomId",
                "RoomNumber");

            return View(reservation);
        }


        [HttpGet]
        public IActionResult Edit(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var reservation = _Context.Reservations.Find(id);
            if (reservation == null)
            {
                return Index();
            }
            ViewBag.RoomId = new SelectList(_Context.Rooms.Where(r => r.IsAvailable == true), "RoomId", "RoomNumber");
            ViewBag.CustomerId = new SelectList(_Context.Customers, "CustomerId", "CustomerId" );

            return View(reservation);
        }

        [HttpPost]
        public IActionResult Edit(int id, Reservation reservation)
        {
            if (reservation == null)
            {
                return BadRequest("Reservation data is missing.");
            }

            if (id != reservation.ReservationId)
            {
                return NotFound();
            }

            try
            {
                var existingReservation = _Context.Reservations.Find(id);
                if (existingReservation == null)
                {
                    return NotFound();
                }

                // Check if the room has changed
                if (existingReservation.RoomId != reservation.RoomId)
                {
                    var oldRoom = _Context.Rooms.Find(existingReservation.RoomId);
                    var newRoom = _Context.Rooms.Find(reservation.RoomId);

                    if (oldRoom != null)
                    {
                        oldRoom.IsAvailable = true;
                        _Context.Rooms.Update(oldRoom);
                    }

                    if (newRoom != null)
                    {
                        newRoom.IsAvailable = false;
                        _Context.Rooms.Update(newRoom);
                    }
                }

                // Update the reservation
                existingReservation.RoomId = reservation.RoomId;
                existingReservation.CustomerId = reservation.CustomerId;
                existingReservation.CheckInDate = reservation.CheckInDate;
                existingReservation.CheckOutDate = reservation.CheckOutDate;

                _Context.Reservations.Update(existingReservation);
                _Context.SaveChanges();

                if (existingReservation.RoomId != reservation.RoomId)
                {
                    _Context.SaveChanges();
                }
            }
            catch (Exception ex)
            {
                // Log the exception (consider using a logging framework)
                return BadRequest($"An error occurred: {ex.Message}");
            }

            return RedirectToAction(nameof(Index));
        }

        [HttpGet]
        public IActionResult Delete(int? id)
        {
            if (id == 0 || id == null)
            {
                return NotFound();
            }
            var reservation = _Context.Reservations.Include(c => c.Customer).Include(r => r.Room).FirstOrDefault(r => r.ReservationId == id);
            if (reservation == null)
            {
                return Index();
            }
            return View(reservation);
        }

        [HttpPost]
        public IActionResult Delete(int id, IFormCollection form)
        {
            try
            {
                var reservation = _Context.Reservations.Find(id);
                if (reservation != null)
                {
                    var room = _Context.Rooms.Find(reservation.RoomId);
                    if (room != null)
                    {
                        room.IsAvailable = true;
                        _Context.Rooms.Update(room);
                    }

                    _Context.Reservations.Remove(reservation);
                    _Context.SaveChanges();
                }
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}


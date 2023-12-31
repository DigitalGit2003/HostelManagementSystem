﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using HostelManagementSystem.Data;
using HostelManagementSystem.Models;
using System.Net;

namespace HostelManagementSystem.Controllers
{
    public class RoomsController : Controller
    {
        private readonly AppDbContext _context;

        public RoomsController(AppDbContext context)
        {
            _context = context;
        }

        // GET: Rooms
        public async Task<IActionResult> Index()
        {
            return _context.rooms != null ?
                        View(await _context.rooms.ToListAsync()) :
                        Problem("Entity set 'AppDbContext.rooms'  is null.");
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // GET: Rooms/Create
        public IActionResult Create()
        {
            return View();
        }

        // POST: Rooms/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create([Bind("Id,roomNo,type,capacity,vacancy")] Room room)
        {
            //if (ModelState.IsValid)
            //{
            room.vacancy = room.capacity;
            _context.Add(room);
            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
            //}
            return View(room);
        }

        // GET: Rooms/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms.FindAsync(id);
            if (room == null)
            {
                return NotFound();
            }
            return View(room);
        }

        // POST: Rooms/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,roomNo,type,capacity")] Room room)
        {
            if (id != room.Id)
            {
                return NotFound();
            }

            //if (ModelState.IsValid)
            //{
            try
            {

                Room beforeRenovationRoom = await _context.rooms.FirstOrDefaultAsync(x => x.Id == id);
                int alreadyOccupied = beforeRenovationRoom.capacity - beforeRenovationRoom.vacancy;
                if (room.capacity >= alreadyOccupied)
                {
                    int newVacancy = beforeRenovationRoom.vacancy + (room.capacity - beforeRenovationRoom.capacity);
                    room.vacancy = newVacancy;

                    // we need to detach one of "beforeRenovationRoom" or "room".
                    // because EF core can't track two instanses with same id
                    // (here "beforeRenovationRoom" and "room" have same id). 
                    _context.Entry(beforeRenovationRoom).State = EntityState.Detached;

                    _context.Update(room);
                    await _context.SaveChangesAsync();
                    return RedirectToAction(nameof(Index));
                }
                else
                {
                    // give message on frontend that can't change capacity....

                    // ################################# First Approach by changing page #################################

                    //// Provide a message to the frontend indicating that the capacity cannot be changed.
                    //string errorMessage = "Cannot change capacity. new capacity is less than current occupancy.";

                    //// You can return this message to the frontend or use it as needed.

                    //// For example, if you're in a controller action, you can return a response with the message:
                    //return BadRequest(errorMessage);

                    //// Or if you're working with an API, you can set an appropriate status code and return the message as JSON:
                    //return new JsonResult(new { ErrorMessage = errorMessage })
                    //{
                    //    StatusCode = (int)HttpStatusCode.BadRequest
                    //};

                    // ################################ Second Approach of errmsg on same page ##########################
                    TempData["ErrorMessage"] = "Cannot change capacity. New capacity is less than current occupancy of room.";
                    return View();

                }
            }
            catch (DbUpdateConcurrencyException)
            {
                if (!RoomExists(room.Id))
                {
                    return NotFound();
                }
                else
                {
                    throw;
                }
            }
            //}
            return View(room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            var room = await _context.rooms
                .FirstOrDefaultAsync(m => m.Id == id);
            if (room == null)
            {
                return NotFound();
            }

            return View(room);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            if (_context.rooms == null)
            {
                return Problem("Entity set 'AppDbContext.rooms'  is null.");
            }
            var room = await _context.rooms.FindAsync(id);
            if (room != null)
            {
                _context.rooms.Remove(room);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool RoomExists(int id)
        {
            return (_context.rooms?.Any(e => e.Id == id)).GetValueOrDefault();
        }

        // GET: Rooms/Details/5
        public async Task<IActionResult> DisplayRoomies(int? id)
        {
            if (id == null || _context.rooms == null)
            {
                return NotFound();
            }

            IEnumerable<Student> students = await _context.rooms
                                    .Where(room => room.Id == id) // Filter by the specified room id
                                    .SelectMany(room => room.Students) // Select the students within the room
                                    .ToListAsync();
            if (students == null)
            {
                return NotFound();
            }

            return View(students);
        }
    }
}

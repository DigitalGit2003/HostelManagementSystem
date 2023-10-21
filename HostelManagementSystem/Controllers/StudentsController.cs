using HostelManagementSystem.Data;
using HostelManagementSystem.Models;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace HostelManagementSystem.Controllers
{
    public class StudentsController : Controller
    {
        private readonly AppDbContext _context;

        public StudentsController(AppDbContext context)
        {
            _context = context;
        }
        public IActionResult Index()
        {
            return View();
        }

        public IActionResult Profile()
        {
            string user_email = User.Identity.Name;
            Room user_room = _context.rooms.Include(r => r.Students).FirstOrDefault(r => r.Students.Any(s => s.Email == user_email));


            return View(user_room);
        }

        // GET: Rooms/Delete/5
        public async Task<IActionResult> Delete(string? id)
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students
                .FirstOrDefaultAsync(m => m.Id == id.ToString());
            if (student == null)
            {
                return NotFound();
            }

            return View(student);
        }

        // POST: Rooms/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(string id)
        {
            if (_context.students == null)
            {
                return Problem("Entity set 'AppDbContext.students'  is null.");
            }
            var student = await _context.students.FindAsync(id);
            if (student != null)
            {
                // ############ After Removing student, vacancy++ ##########################3
                Room room = _context.rooms.FirstOrDefault(x => x.Id == student.roomId);
                room.vacancy++;
                _context.Update(room);
                _context.SaveChanges();

                // ############## Now, Delete student #############################
                _context.students.Remove(student);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index), "Rooms");
        }


        // GET: Student/Edit/5
        public async Task<IActionResult> Edit(string? id) /// id of student is string
        {
            if (id == null || _context.students == null)
            {
                return NotFound();
            }

            var student = await _context.students.FindAsync(id);
            if (student == null)
            {
                return NotFound();
            }
            return View(student);
        }

        // POST: Student/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(string id, [Bind("Id,Name,Phone,Status,ZipCode")] Student student)
        {
            if (id != student.Id)
            {
                return NotFound();
            }


            Student stu = await _context.students.FirstOrDefaultAsync(x => x.Id == id);

            Room room = _context.rooms.FirstOrDefault(x => x.Id == stu.roomId);

            int roomNo = room.roomNo;

            //if (ModelState.IsValid)
            //{
            try
                {   
                    stu.Name = student.Name;
                    stu.Phone = student.Phone;
                    stu.Status = student.Status;
                    stu.ZipCode = student.ZipCode;
                    _context.Update(stu);
                    await _context.SaveChangesAsync();


                }
                catch (DbUpdateConcurrencyException)
                {
                    //if (!RoomExists(room.Id))
                    //{
                    //    return NotFound();
                    //}
                    //else
                    //{
                    //    throw;
                    //}
                }
                return RedirectToAction("DisplayRoomies", "Rooms", new {id = roomNo});
            //}
            return View(student);
        }

    }
}

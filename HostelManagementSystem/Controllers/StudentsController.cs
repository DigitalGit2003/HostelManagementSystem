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

        public IActionResult Details()
        {
            string user_email = User.Identity.Name;
            Room user_room = _context.rooms.Include(r => r.Students).FirstOrDefault(r => r.Students.Any(s => s.Email == user_email));


            return View(user_room);
        }

    }
}

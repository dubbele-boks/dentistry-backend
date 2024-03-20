using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using System.Security.Claims;

namespace mvc.Controllers
{
    public class DentistController : Controller
    {
        private ApplicationDbContext _context;
        public DentistController(ApplicationDbContext context) { 
            _context = context;
        }

        async public Task<IActionResult> Stats()
        {
            var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);
            var stats = await _context.AppointmentTreatment
                .Include(x => x.Treatment)
                .Include(x => x.Appointment)
                .ThenInclude(a => a.Dentist)
                .Where(x => x.Appointment.DentistId == userId)
                .GroupBy(x => x.Treatment.Name)
                .Select(x => new { name = x.Key, count = x.Count() })
                .ToListAsync();


            ViewBag.stats = stats;
            return View();
        }
    }
}

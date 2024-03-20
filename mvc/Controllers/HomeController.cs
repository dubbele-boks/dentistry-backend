using DataAccess;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using System.Diagnostics;
using System.Security.Claims;

namespace mvc.Controllers
{
    public class HomeController : Controller
    {
        private readonly ILogger<HomeController> _logger;
        private ApplicationDbContext context;
        public HomeController(ILogger<HomeController> logger, ApplicationDbContext _context)
        {
            context = _context;
            _logger = logger;
        }

        public IActionResult Index()
        {
            return View();
        }

        async public Task<IActionResult> Team()
        {
            ViewBag.dentists = await context.Dentists.ToListAsync();
            ViewBag.assistants = await context.Assistents.ToListAsync();
            return View();
        }

        public IActionResult Vision() { 
            return View();
        }

        public IActionResult Privacy()
        {
            return View();
        }

        async public Task<IActionResult> Treatments()
        {
            ViewBag.treatments = await context.Treatment.ToListAsync();
            return View();
        }

        [Authorize]
        async public Task<IActionResult> TreatmentsHistory()
        {
            if (User.Identity.IsAuthenticated)
            {
                // Getting the user id
                string userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                // Get all appointments of the user
                var appointments = await context.Appointment.Where(p => p.PatientId == userId).ToListAsync();

                if (appointments != null && appointments.Any())
                {
                    // Create a list to store appointment dates
                    List<DateTime> appointmentDates = new List<DateTime>();

                    // Create a list to store treatments
                    List<Treatment> treatments = new List<Treatment>();

                    foreach (var appointment in appointments)
                    {
                        // Store appointment date
                        appointmentDates.Add((DateTime)appointment.Date);

                        // Get all treatments for this appointment
                        var appointmenttreatments = await context.AppointmentTreatment.Where(a => a.AppointmentId == appointment.Id).ToListAsync();

                        if (appointmenttreatments != null && appointmenttreatments.Any())
                        {
                            foreach (var appointmenttreatment in appointmenttreatments)
                            {
                                // Get the treatment and add it to the treatments list
                                var treatment = await context.Treatment.FirstOrDefaultAsync(t => t.Id == appointmenttreatment.TreatmentId);
                                if (treatment != null)
                                {
                                    treatments.Add(treatment);
                                }
                            }
                        }
                    }

                    // Pass appointment dates and treatments to the ViewBag
                    ViewBag.appointmentDates = appointmentDates;
                    ViewBag.treatments = treatments;
                }
            }

            return View();
        }




        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

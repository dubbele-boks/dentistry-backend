using DataAccess;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using System.Diagnostics;

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

        [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
        public IActionResult Error()
        {
            return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
        }
    }
}

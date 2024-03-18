using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;
using System.Reflection.PortableExecutable;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;

        public EmployeeController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: EmployeesController
        async public Task<ActionResult> Index()
        {
            ViewBag.dentists = await _context.Dentists.ToListAsync();
            ViewBag.assistents = await _context.Assistents.ToListAsync();
            return View();
        }

        // GET: EmployeesController/Details/5
        public ActionResult Details(int id)
        {
            return View();
        }

        // GET: EmployeesController/Create
        public ActionResult CreateDentist()
        {
            return View();
        }
        // GET: EmployeesController/Create
        public ActionResult CreateAssistent()
        {
            return View();
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> CreateDentist(Dentist dentist)
        {
            try
            {
                Dentist test = new Dentist() { FirstName = dentist.FirstName, MiddleName = dentist.MiddleName, LastName = dentist.LastName, Email = dentist.Email, PasswordHash = dentist.PasswordHash, PhoneNumber = dentist.PhoneNumber, BirthDate = dentist.BirthDate };
                await _context.Dentists.AddAsync(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> CreateAssistent(Assistent dentist)
        {
            try
            {
                Assistent test = new Assistent() { FirstName = dentist.FirstName, MiddleName = dentist.MiddleName, LastName = dentist.LastName, Email = dentist.Email, PasswordHash = dentist.PasswordHash, PhoneNumber = dentist.PhoneNumber, BirthDate = dentist.BirthDate };
                await _context.Assistents.AddAsync(test);
                await _context.SaveChangesAsync();
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Edit/5
        public ActionResult Edit(int id)
        {
            return View();
        }

        // POST: EmployeesController/Edit/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Edit(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }

        // GET: EmployeesController/Delete/5
        public ActionResult Delete(int id)
        {
            return View();
        }

        // POST: EmployeesController/Delete/5
        [HttpPost]
        [ValidateAntiForgeryToken]
        public ActionResult Delete(int id, IFormCollection collection)
        {
            try
            {
                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return View();
            }
        }
    }
}

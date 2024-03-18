using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity.UI.Services;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Migrations;
using mvc.Models;
using System.Reflection.PortableExecutable;

namespace mvc.Controllers
{
    public class EmployeeController : Controller
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly IUserStore<ApplicationUser> _userStore;
        private readonly IUserEmailStore<ApplicationUser> _emailStore;

        public EmployeeController(ApplicationDbContext context, UserManager<ApplicationUser> userManager,
            IUserStore<ApplicationUser> userStore, IEmailSender emailSender)
        {
            _context = context;
            _userManager = userManager;
            _userStore = userStore;
            _emailStore = GetEmailStore();
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
                var user = Activator.CreateInstance<Dentist>();

                user.FirstName = dentist.FirstName;
                user.MiddleName = dentist.MiddleName;
                user.LastName = dentist.LastName;
                user.PhoneNumber = dentist.PhoneNumber;
                user.BirthDate = dentist.BirthDate;
                user.EmailConfirmed = true;

                await _userStore.SetUserNameAsync(user, dentist.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, dentist.Email, CancellationToken.None);
                await _userManager.CreateAsync(user, dentist.PasswordHash!);
                await _userManager.AddToRoleAsync(user, "Dentist");
                

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
            }
        }

        // POST: EmployeesController/Create
        [HttpPost]
        [ValidateAntiForgeryToken]
        async public Task<ActionResult> CreateAssistent(Assistent assistent)
        {
            try
            {
                var user = Activator.CreateInstance<Assistent>();

                user.FirstName = assistent.FirstName;
                user.MiddleName = assistent.MiddleName;
                user.LastName = assistent.LastName;
                user.PhoneNumber = assistent.PhoneNumber;
                user.BirthDate = assistent.BirthDate;
                user.EmailConfirmed = true;

                await _userStore.SetUserNameAsync(user, assistent.Email, CancellationToken.None);
                await _emailStore.SetEmailAsync(user, assistent.Email, CancellationToken.None);
                await _userManager.CreateAsync(user, assistent.PasswordHash!);
                await _userManager.AddToRoleAsync(user, "Assistant");

                return RedirectToAction(nameof(Index));
            }
            catch
            {
                return RedirectToAction(nameof(Index));
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
        private IUserEmailStore<ApplicationUser> GetEmailStore()
        {
            if (!_userManager.SupportsUserEmail)
            {
                throw new NotSupportedException("The default UI requires a user store with email support.");
            }
            return (IUserEmailStore<ApplicationUser>)_userStore;
        }
    }
}

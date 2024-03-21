using System;
using System.Collections.Generic;
using System.Linq;
using System.Security.Claims;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Mvc;
using Microsoft.AspNetCore.Mvc.Rendering;
using Microsoft.EntityFrameworkCore;
using mvc.Data;
using mvc.Models;

namespace mvc.Controllers
{
    public class AppointmentController : Controller
    {
        private readonly ApplicationDbContext _context;

        public AppointmentController(ApplicationDbContext context)
        {
            _context = context;
        }

        // GET: Appointment
        public async Task<IActionResult> Index()
        {
            var patientNames = _context.Patients.Select(p => new {
                Id = p.Id,
                FullName = p.FirstName + " " + p.MiddleName + " " + p.LastName
            }).ToList();
            var DentistNames = _context.Dentists.Select(p => new {
                Id = p.Id,
                FullName = p.FirstName + " " + p.MiddleName + " " + p.LastName
            }).ToList();
            var Room = _context.Room.Where(e => e.Rented).Select(p => new {
                Id = p.Id,
                RoomNumber = p.Roomnumber
            }).ToList();
            var Treatment = _context.Treatment.Select(p => new { 
                Id = p.Id,
                Name = p.Name,
            }).ToList();

            ViewData["PatientId"] = new SelectList(patientNames, "Id", "FullName");
            ViewData["DentistId"] = new SelectList(DentistNames, "Id", "FullName");
            ViewData["RoomId"] = new SelectList(Room, "Id", "RoomNumber");
            ViewData["Treatments"] = new SelectList(Treatment, "Id", "Name");

            if (User.IsInRole("Assistant")) {
                return View("Assistant");
            } else {
                var userId = User.FindFirstValue(ClaimTypes.NameIdentifier);

                ViewBag.appointments = await _context.AppointmentTreatment
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Dentist)
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Room)
                    .Where(x => x.Appointment.DentistId == userId )
                    .ToListAsync();
                return View("Dentist");
            }
        }

        public async Task<IActionResult> LinkNote(int AppointmentId, string title, string description) {
            Note note = new Note { 
                Title = title,
                Description = description
            };

            await _context.Note.AddAsync(note);

            Appointment appointment = _context.Appointment.Find(AppointmentId);
            appointment.Notes.Add(note);
            await _context.SaveChangesAsync();

            return RedirectToAction("Details", new { id = AppointmentId });
        }

        // GET: Appointment/Details/5
        public async Task<IActionResult> Details(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

           var appointment = await _context.AppointmentTreatment
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Dentist)
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Patient)
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Room)
                    .Include(p => p.Appointment)
                    .ThenInclude(a => a.Notes)
                    .FirstOrDefaultAsync(m => m.Appointment.Id == id);

            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

      
        // POST: Appointment/Create
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Create(List<int> Treatments, int room, string patient, string dentist, string date)
        {
            Appointment app = new Appointment
            {
                Dentist = _context.Dentists.Find(dentist),
                Patient = _context.Patients.Find(patient),
                Date = DateTime.Parse(date),
                Room = _context.Room.Find(room),
            };
            await _context.Appointment.AddAsync(app);

            foreach (int treatment in Treatments) {
                Treatment treat = _context.Treatment.Find(treatment)!;
                AppointmentTreatment apt = new AppointmentTreatment
                {
                    Appointment = app,
                    Treatment = treat,
                    OldPrice = (double)treat.Price,
                };
                await _context.AppointmentTreatment.AddAsync(apt);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        // GET: Appointment/Edit/5
        public async Task<IActionResult> Edit(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment == null)
            {
                return NotFound();
            }
            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "Id", appointment.DentistId);
            return View(appointment);
        }

        // POST: Appointment/Edit/5
        // To protect from overposting attacks, enable the specific properties you want to bind to.
        // For more details, see http://go.microsoft.com/fwlink/?LinkId=317598.
        [HttpPost]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> Edit(int id, [Bind("Id,DentistId,Date")] Appointment appointment)
        {
            if (id != appointment.Id)
            {
                return NotFound();
            }

            if (ModelState.IsValid)
            {
                try
                {
                    _context.Update(appointment);
                    await _context.SaveChangesAsync();
                }
                catch (DbUpdateConcurrencyException)
                {
                    if (!AppointmentExists(appointment.Id))
                    {
                        return NotFound();
                    }
                    else
                    {
                        throw;
                    }
                }
                return RedirectToAction(nameof(Index));
            }
            ViewData["DentistId"] = new SelectList(_context.Dentists, "Id", "Id", appointment.DentistId);
            return View(appointment);
        }

        // GET: Appointment/Delete/5
        public async Task<IActionResult> Delete(int? id)
        {
            if (id == null)
            {
                return NotFound();
            }

            var appointment = await _context.Appointment
                .Include(a => a.Dentist)
                .FirstOrDefaultAsync(m => m.Id == id);
            if (appointment == null)
            {
                return NotFound();
            }

            return View(appointment);
        }

        // POST: Appointment/Delete/5
        [HttpPost, ActionName("Delete")]
        [ValidateAntiForgeryToken]
        public async Task<IActionResult> DeleteConfirmed(int id)
        {
            var appointment = await _context.Appointment.FindAsync(id);
            if (appointment != null)
            {
                _context.Appointment.Remove(appointment);
            }

            await _context.SaveChangesAsync();
            return RedirectToAction(nameof(Index));
        }

        private bool AppointmentExists(int id)
        {
            return _context.Appointment.Any(e => e.Id == id);
        }
    }
}

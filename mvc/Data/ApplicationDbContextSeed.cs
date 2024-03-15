using Microsoft.AspNetCore.Identity;
using mvc.Models;
using System.Net;

namespace mvc.Data
{
    public class ApplicationDbContextSeed
    {
        public async Task<bool> SeedEssentialsAsync(UserManager<ApplicationUser> userManager,
                                                   RoleManager<IdentityRole> roleManager, ApplicationDbContext context)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole("Dentist"));
            await roleManager.CreateAsync(new IdentityRole("Assistant"));
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
            await roleManager.CreateAsync(new IdentityRole("ApplicationUser"));


            var dentist = Activator.CreateInstance<Dentist>();
            var assistent = Activator.CreateInstance<Assistent>();
            var admin = Activator.CreateInstance<ApplicationUser>();
            var patient = Activator.CreateInstance<Patient>();
            dentist.FirstName = "Jansen";
            dentist.LastName = "jansen";
            dentist.Email = "j.driekwartslag@gmail.com";
            dentist.EmailConfirmed = true;
            dentist.PhoneNumberConfirmed = true;

            assistent.FirstName = "Roos";
            assistent.LastName = "Roos";
            assistent.Email = "r.boos@gmail.com";
            assistent.EmailConfirmed = true;
            assistent.PhoneNumberConfirmed = true;

            admin.FirstName = "admin";
            admin.LastName = "admin";
            admin.Email = "admin@gmail.com";
            admin.EmailConfirmed = true;
            admin.PhoneNumberConfirmed = true;

            patient.FirstName = "guus";
            patient.LastName = "batspak";
            patient.Email = "g.batspak@gmail.com";
            patient.EmailConfirmed = true;
            patient.PhoneNumberConfirmed = true;
            patient.Dentist = dentist;

            await context.Dentists.AddAsync(dentist);
            await context.Assistents.AddAsync(assistent);
            await context.Patients.AddAsync(patient);
            await context.applicationUsers.AddAsync(admin);

            //await userManager.AddToRoleAsync(admin, "Administrator");
            //await userManager.AddToRoleAsync(dentist, "Dentist");
            //await userManager.AddToRoleAsync(patient, "ApplicationUser");
            //await userManager.AddToRoleAsync(assistent, "Assistant");

            await context.SaveChangesAsync();
            return true;
        }
    }
}

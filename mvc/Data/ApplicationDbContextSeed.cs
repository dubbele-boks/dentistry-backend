using Microsoft.AspNetCore.Identity;
using mvc.Models;
using System.Net;

namespace mvc.Data
{
    public class ApplicationDbContextSeed
    {
        public async Task<bool> SeedEssentialsAsync(UserManager<ApplicationUser> userManager,
                                                   RoleManager<IdentityRole> roleManager)
        {
            //Seed Roles
            await roleManager.CreateAsync(new IdentityRole("Dentist"));
            await roleManager.CreateAsync(new IdentityRole("Assistant"));
            await roleManager.CreateAsync(new IdentityRole("Administrator"));
            await roleManager.CreateAsync(new IdentityRole("ApplicationUser"));



            var dentist = new Dentist
            {
                UserName = "Jansen",
                FirstName = "Jansen",
                LastName = "Driekwartslag",
                Email= "j.driekwartslag@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var assistent = new Assistent
            {
                UserName = "Roos",
                FirstName = "Roos",
                LastName = "Boos",
                Email = "r.boos@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var admin = new ApplicationUser
            {
                UserName = "admin",
                FirstName = "admin",
                LastName = "admin",
                Email = "admin@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
            };
            var patient = new Patient
            {
                UserName = "guus",
                FirstName = "guus",
                LastName = "batspak",
                Email = "g.batspak@gmail.com",
                EmailConfirmed = true,
                PhoneNumberConfirmed = true,
                Dentist = dentist,
            };

            if (userManager.Users.All(u => u.Id != assistent.Id))
            {
                await userManager.CreateAsync(assistent, "test123");
                await userManager.AddToRoleAsync(assistent, "Assistant");
            }

            if (userManager.Users.All(u => u.Id != admin.Id))
            {
                await userManager.CreateAsync(admin, "test123");
                await userManager.AddToRoleAsync(admin, "Administrator");
            }

            if (userManager.Users.All(u => u.Id != patient.Id))
            {
                await userManager.CreateAsync(patient, "test123");
                await userManager.AddToRoleAsync(patient, "ApplicationUser");
            }

            if (userManager.Users.All(u => u.Id != dentist.Id))
            {
                await userManager.CreateAsync(dentist, "test123");
                await userManager.AddToRoleAsync(dentist, "Dentist");
            }



            return true;
        }
    }
}

using Microsoft.AspNetCore.Cryptography.KeyDerivation;
using Microsoft.AspNetCore.Identity;
using mvc.Models;
using System.Net;
using System.Security.Cryptography;

namespace mvc.Data
{
    public class ApplicationDbContextSeed
    {
        public byte[] salt = RandomNumberGenerator.GetBytes(128 / 8); // divide by 8 to convert bits to bytes
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

            string password = "AQAAAAIAAYagAAAAEC5Yny/CGNzHmQzQJVvHByQMoPc44rOitUybK66sfS1it+D6hL4jLEFtSjwkUPTatw==";
            

            dentist.FirstName = "Jansen";
            dentist.LastName = "jansen";
            dentist.Email = "j.driekwartslag@gmail.com";
            dentist.NormalizedEmail = "j.driekwartslag@gmail.com".ToUpper();
            dentist.UserName = "DoctorJansen";
            dentist.NormalizedUserName = "DoctorJansen".ToUpper();
            dentist.EmailConfirmed = true;
            dentist.PhoneNumberConfirmed = true;
            dentist.PasswordHash = password;

            assistent.FirstName = "Roos";
            assistent.LastName = "Roos";
            assistent.Email = "r.boos@gmail.com";
            assistent.NormalizedEmail = "r.boos@gmail.com".ToUpper();
            assistent.UserName = "AssistentRoos";
            assistent.NormalizedUserName = "AssistentRoos".ToUpper();
            assistent.EmailConfirmed = true;
            assistent.PhoneNumberConfirmed = true;
            assistent.PasswordHash = password;


            admin.FirstName = "admin";
            admin.LastName = "admin";
            admin.Email = "admin@gmail.com";
            admin.NormalizedEmail = "admin@gmail.com".ToUpper();
            admin.UserName = "admin";
            admin.NormalizedUserName = "admin".ToUpper();
            admin.EmailConfirmed = true;
            admin.PhoneNumberConfirmed = true;
            admin.PasswordHash = password;


            patient.FirstName = "guus";
            patient.LastName = "batspak";
            patient.Email = "g.batspak@gmail.com";
            patient.NormalizedEmail = "g.batspak@gmail.com";
            patient.UserName = "PatientGuus";
            patient.NormalizedUserName = "PatientGuus".ToUpper();
            patient.EmailConfirmed = true;
            patient.PhoneNumberConfirmed = true;
            patient.Dentist = dentist;
            patient.PasswordHash = password;

            await context.Dentists.AddAsync(dentist);
            await context.Assistents.AddAsync(assistent);
            await context.Patients.AddAsync(patient);
            await context.applicationUsers.AddAsync(admin);

            await context.SaveChangesAsync();

            await userManager.AddToRoleAsync(admin, "Administrator");
            await userManager.AddToRoleAsync(dentist, "Dentist");
            await userManager.AddToRoleAsync(patient, "ApplicationUser");
            await userManager.AddToRoleAsync(assistent, "Assistant");
            return true;
        }
    }
}

using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using mvc.Models;

namespace mvc.Data
{
    public class ApplicationDbContext : IdentityDbContext<ApplicationUser>
    {

        public DbSet<Dentist> Dentists { get; set; }
        public DbSet<Assistent> Assistents { get; set; }
        public DbSet<Patient> Patients { get; set; }
        public DbSet<ApplicationUser> applicationUsers { get; set; }
        public DbSet<Address> Address { get; set; }

        public DbSet<Appointment> Appointment { get; set; }
        public DbSet<AppointmentTreatment> AppointmentTreatment { get; set; }

        public DbSet<Room> Room { get; set; }

        public DbSet<Treatment> Treatment { get; set; }

        public DbSet<Note> Note { get; set; }

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);
            modelBuilder.Entity<ApplicationUser>().UseTptMappingStrategy();
            modelBuilder.Entity<ApplicationUser>().HasData(
               new ApplicationUser() { FirstName = "admin", LastName = "admin", BirthDate = new DateOnly(2023, 10, 12), Email = "admin@test.com"}
            );
            modelBuilder.Entity<Patient>().HasData(
                 new Patient() { FirstName = "test", LastName = "deTest", BirthDate = new DateOnly(2019, 5, 2), Email = "test@test.com" }        
            );
            modelBuilder.Entity<Dentist>().HasData(
                new Dentist() { FirstName = "Jans", LastName = "Harksen", BirthDate = new DateOnly(2023, 10, 12), Email = "jans.harksen@doctor.com" }
           );
            modelBuilder.Entity<Assistent>().HasData(
               new Assistent() { FirstName = "Roos", LastName = "frederiksen", BirthDate = new DateOnly(2023, 10, 12), Email = "roos.frederiksen@dcotor.com" }
           );
        }
    }
}

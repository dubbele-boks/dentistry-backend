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
        }
    }
}

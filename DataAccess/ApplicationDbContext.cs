using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using System.Diagnostics.Metrics;

namespace DataAccess
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options)
            : base(options)
        {
        }


        public DbSet<Models.Person> Person { get; set; }
        
        public DbSet<Models.Address> Address { get; set; }

        public DbSet<Models.Appointment> Appointment { get; set; }

        public DbSet<Models.Dentist> Dentist { get; set; }
        
        public DbSet<Models.Patient> Patient { get; set; }
        
        public DbSet<Models.Room> Room { get; set; }
        
        public DbSet<Models.Treatment> Treatment { get; set; }
        
        public DbSet<Models.Assistent> Assistent { get; set; }

        public DbSet<Models.Note> Note { get; set; }



    }
}

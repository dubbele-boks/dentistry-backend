using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{ 
    public class ApplicationUser : IdentityUser
    {
        // Additional properties
        public string FirstName { get; set; } = string.Empty;
        public string MiddleName { get; set; } = string.Empty;
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

        public Address? Address { get; set; }


        // Relationships
        //public Address? Address { get; set; }
    }
}

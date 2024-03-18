using Microsoft.AspNetCore.Identity;
using System.ComponentModel.DataAnnotations;
using System.Diagnostics.CodeAnalysis;

namespace mvc.Models
{ 
    public class ApplicationUser : IdentityUser
    {
        // Additional properties
        public string FirstName { get; set; } = string.Empty;

        [AllowNull]
        public string? MiddleName { get; set; }
        public string LastName { get; set; } = string.Empty;
        public DateOnly BirthDate { get; set; }

        public Address? Address { get; set; }


        // Relationships
        //public Address? Address { get; set; }
    }
}

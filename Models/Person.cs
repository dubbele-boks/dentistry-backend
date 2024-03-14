using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Person
    {
        [Key]
        public int ID {  get; set; }

        [Display(Name = "Voornaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Firstname { get; set; } = string.Empty;

        [Display(Name = "Achternaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Lastname { get; set; } = string.Empty;

        [Display(Name = "Tussenvoegsel")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Middlename { get; set; } = string.Empty;

        [DataType(DataType.Date)]
        [Display(Name = "Geboortedatum")]
        public DateTime? Birthday { get; set; }

        [Display(Name = "Emailadres")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; } = string.Empty;

        [Display(Name = "Telefoonnummer")]
        public string? PhoneNumber { get; set; }

        public Address? Address { get; set; }

        public Appointment? Appointment { get; set; }



    }
}

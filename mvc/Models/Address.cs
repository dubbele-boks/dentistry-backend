using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Address
    {
        public int Id {  get; set; }

        [Display(Name = "Straatnaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? Street { get; set; }

        [Display(Name = "Plaatsnaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? City { get; set; }

        [Display(Name = "Postcode")]
        [DataType(DataType.PostalCode)]
        public string? PostalCode {  get; set; }

        [Display(Name = "Huisnummer")]
        public int? HouseNumber { get; set; }

        [Display(Name = "Toevoeging")]
        public string Addition { get; set; } = string.Empty;

        public List<ApplicationUser> ApplicationUsers { get; set; } = new List<ApplicationUser>();
    }
}

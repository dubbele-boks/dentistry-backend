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
        public int id {  get; set; }

        [Display(Name = "Straatnaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? street { get; set; }

        [Display(Name = "Plaatsnaam")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string? city { get; set; }

        [Display(Name = "Postcode")]
        [DataType(DataType.PostalCode)]
        public string? postalCode {  get; set; }

        [Display(Name = "Huisnummer")]
        public int? houseNumber { get; set; }

        [Display(Name = "Toevoeging")]
        public string addition { get; set; } = string.Empty;
    }
}

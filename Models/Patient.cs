using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Patient : Person
    {
        [Display(Name = "Tandarts")]
        public Dentist? Dentist { get; set; } 
    }
}

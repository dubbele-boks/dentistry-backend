using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Appointment
    {
        [Key]
        public int ID { get; set; }

        [Display(Name = "Tandarts")]
        [ForeignKey("Dentist")]
        [Required]
        public Dentist Dentist { get; set; }

        [Display(Name = "Patient")]
        public Patient? Patient { get; set; }

        [Display(Name = "Behandelingen")]
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();

        [DataType(DataType.Date)]
        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }



    }
}

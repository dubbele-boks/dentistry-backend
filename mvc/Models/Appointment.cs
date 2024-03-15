using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Tandarts")]
        [Required]
        public required Dentist Dentist { get; set; }

        [Display(Name = "Patient")]
        [Required]
        public required Patient Patient { get; set; }

        [Display(Name = "Behandelingen")]
        public List<Treatment> Treatments { get; set; } = new List<Treatment>();

        [DataType(DataType.DateTime)]
        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }

        public List<Note> Notes { get; set; } = new List<Note>();

    }
}

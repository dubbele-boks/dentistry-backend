using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Models
{
    public class Dentist : ApplicationUser
    {
        public List<Patient>? Patient { get; set; }

        [ForeignKey("Appointment")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

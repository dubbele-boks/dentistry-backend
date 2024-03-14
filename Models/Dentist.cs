using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Models
{
    public class Dentist : Person
    {
        public int DentistID { get; set; }

        [ForeignKey("Appointments")]
        public List<Appointment> Appointments { get; set; } = new List<Appointment>();
    }
}

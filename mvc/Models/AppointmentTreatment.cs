using Microsoft.EntityFrameworkCore;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace mvc.Models
{
 
    public class AppointmentTreatment
    {
        public int Id { get; set; }

        public int AppointmentId { get; set; }

        [ForeignKey(nameof(AppointmentId))]
        public Appointment Appointment { get; set; } = null!;

        public int TreatmentId { get; set; }
        
        [ForeignKey(nameof(TreatmentId))]
        public Treatment Treatment { get; set; } = null!;

        public double Oldprice {  get; set; } 
    }
}

using System.ComponentModel;

namespace mvc.Models
{
    public class Patient : ApplicationUser
    {
        [DisplayName("Verzekeraar")]
        public string HealthInsurer { get; set; } = string.Empty;

        [DisplayName("Klantennummer")]
        public string CustomerNumber { get; set; } = string.Empty;

        [DisplayName("Tandarts")]
        public Dentist? Dentist { get; set; }
    }
}

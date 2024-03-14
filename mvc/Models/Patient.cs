namespace mvc.Models
{
    public class Patient : ApplicationUser
    {
        public string HealthInsurer { get; set; } = string.Empty;
        public string CustomerNumber { get; set; } = string.Empty;
        public Dentist? Dentist { get; set; }
    }
}

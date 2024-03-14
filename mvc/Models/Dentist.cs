namespace mvc.Models
{
    public class Dentist : ApplicationUser
    {
        public List<Patient>? Patient { get; set; }
    }
}

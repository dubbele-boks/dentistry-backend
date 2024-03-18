using System.ComponentModel.DataAnnotations;

namespace mvc.Models
{
    public class Feedback
    {
        public int Id { get; set; }

        [Display(Name = "Bericht")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Message { get; set; } = string.Empty;
    }
}

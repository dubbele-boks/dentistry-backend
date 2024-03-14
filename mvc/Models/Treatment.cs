using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Treatment
    {
        [Key]
        int Id {  get; set; }

        [StringLength(50)]
        public string name { get; set; }

        [Length(1, 50, ErrorMessage = "")]
        public int minutes {  get; set; }

        public Double? price {  get; set; }
    }
}

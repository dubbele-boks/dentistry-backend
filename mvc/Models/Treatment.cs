using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Treatment
    {
        [Key]
        public int Id {  get; set; }

        [DisplayName("Naam")]
        [StringLength(50)]
        public string Name { get; set; }

        [DisplayName("Minuten")]
        public int Minutes {  get; set; }

        [DisplayName("Prijs")]
        public Double? Price {  get; set; }
    }
}

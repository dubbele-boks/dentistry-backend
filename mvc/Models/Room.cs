using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Room
    {
        [Key]
        public int Id { get; set; }

        [DisplayName("Kamernummer")]
        public required int Roomnumber { get; set; }

        [DisplayName("Verhuurd")]
        public bool Rented { get; set; } = false;
    }
}

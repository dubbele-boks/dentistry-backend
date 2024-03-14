using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models
{
    public class Room
    {
        [Key]
        public int ID { get; set; }

        public required int Roomnumber { get; set; }

        public bool Rented { get; set; } = false;
    }
}

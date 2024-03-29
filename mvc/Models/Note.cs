﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Note
    {
        [Key]
        public int Id { get; set; }

        [Display(Name = "Title")]
        [StringLength(50, ErrorMessage = "Maximumlengte van {0} is {1} tekens")]
        public string Title { get; set; } = string.Empty;


    }
}

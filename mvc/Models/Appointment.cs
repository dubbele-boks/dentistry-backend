﻿using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace mvc.Models
{
    public class Appointment
    {
        [Key]
        public int Id { get; set; }


        [Display(Name = "Tandarts")]
        [Required]
        [ForeignKey(nameof(DentistId))]
        public required Dentist Dentist { get; set; }

        public string DentistId { get; set; }


        [Display(Name = "Patient")]
        [Required]
        public required Patient Patient { get; set; }
        public string PatientId { get; set; }

        [DataType(DataType.DateTime)]
        [Display(Name = "Datum")]
        public DateTime? Date { get; set; }



        //[Display(Name = "Kamer")]
        //public required Room Room { get; set; }
        //[Display(Name = "Bericht")]
        //public required Feedback Feedback { get; set; }

        [Display(Name = "Kamer")]
        [Required]
        [ForeignKey(nameof(Room))]
        public int RoomId { get; set; }
        public Room Room { get; set; }

        [Display(Name = "Feedback")]
        [Required]
        [ForeignKey(nameof(Feedback))]
        public int FeedbackId { get; set; }
        public Feedback Feedback { get; set; }




        [Display(Name = "Notities")]
        public List<Note> Notes { get; set; } = new List<Note>();
    }
}

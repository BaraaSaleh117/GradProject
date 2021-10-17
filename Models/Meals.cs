using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Diadiabetes_App.Models
{
    public partial class Meals
    {
        public int Id { get; set; }

        [Required]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]

        public Patient Patient { get; set; }
        public string Mealname { get; set; }
        public string Mealingredients { get; set; }
        public string Mealtype { get; set; }
        public TimeSpan Mealtime { get; set; }
    }
}

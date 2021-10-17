using Diadiabetes_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Diadiabetes_App.model
{
    public partial class Account
    {
        public int Id { get; set; }
        [Required]
        [Display(Name = "Doctor")]
        public long DoctorId { get; set; }
        [ForeignKey("DoctorId")]
        public Doctor Doctor { get; set; }
        [Required]
        [Display(Name = "Patient")]
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Email { get; set; }
        public int IsDoctor { get; set; }
        public string DocPhoneNumber { get; set; }
    }
}

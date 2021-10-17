using Diadiabetes_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Diadiabetes_App.model
{
    public partial class PatientRecords
    {
       
        public long Id { get; set; }
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
        public string FullName { get; set; }
        public string HealthStatus { get; set; }
        public long? SugerLevelInBlood { get; set; }
        public string ExistingDiseases { get; set; }
        public string Drugs { get; set; }
        public string ChronicDiseases { get; set; }
    }
}

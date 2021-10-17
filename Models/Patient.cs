
using Diadiabetes_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

namespace Diadiabetes_App.Models
{
    public class Patient
    {
        [Key]
        [Required]
        public long Id { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string FirstName { get; set; }

        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        [RegularExpression("^[A-Za-z]+$")]
        public string LastName { get; set; }
        [DataType(DataType.Date)]
        public DateTime? Birthday { get; set; }
        public string Gender { get; set; }
        [DataType(DataType.PhoneNumber)]
        public String PhoneNumber { get; set; }
        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public string Address { get; set; }
        [DataType(DataType.DateTime)]
        public DateTime? RegisterationDate { get; set; }
        

        public List<Appointment> Appointments { get; set; }

        public List<Medical_Informations> Medical_Informations { get; set; }
        [NotMapped]
        public string PatientName
        {
            get { return $"{FirstName} {LastName} {Gender}"; }

        }
    }
}

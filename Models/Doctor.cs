using Diadiabetes_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace Diadiabetes_App.Models
{
    public class Doctor
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

        [StringLength(100, ErrorMessage = "Maximum length is {1}")]
        public string Address { get; set; }

        [DataType(DataType.MultilineText)]
        [Column(TypeName = "text")]
        public string Notes { get; set; }
        [DataType(DataType.PhoneNumber)]
        public string PhoneNumber { get; set; }

        [DataType(DataType.EmailAddress)]
        public string Email { get; set; }
        public IList<Appointment> Appointments { get; set; }


        [NotMapped]
        public string DoctorName
        {
            get
            {
                return $"{FirstName} {LastName}";
            }

        }
        public string DoctorFullName
        {
            get
            {
                return FirstName + LastName;
            }

        }

    }
}


using Diadiabetes_App.model;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;


namespace Diadiabetes_App.Models
{
    public class Medical_Informations
    {
        [Key]
        [Required]
        public long Id { get; set; }
        [StringLength(50, ErrorMessage = "Maximum length is {1}")]
        public string Description { get; set; }
        [Display(Name = "Patient")]
        public long PatientId { get; set; }
        [ForeignKey("PatientId")]
        public Patient Patient { get; set; }

        [Display(Name = "Graphs")]
        public int graphId { get; set; }
        [ForeignKey("graphId")]
        public Graphs Graphs { get; set; }








    }
}

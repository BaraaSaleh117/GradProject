using Diadiabetes_App.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Diadiabetes_App.model
{
    public partial class BodyCompositionData
    {
        [Key]
        [Required]
        public int Id { get; set; }

        [Display(Name = "Medical_Informations")]
        public long MIAD { get; set; }
        [ForeignKey("MIAD")]
        public Medical_Informations Medical_Informations { get; set; }

        [Display(Name = "Notifications")]
        public long NotificationsId { get; set; }
        [ForeignKey("NotificationsId")]
        public Notification Notifications { get; set; }
        public int? Minerals { get; set; }
        public long? Protein { get; set; }
        public long? Weight { get; set; }
        public long? TotalBodyWater { get; set; }
        public long? BodyFatMass { get; set; }
        public long? BloodSugerLevel { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.ComponentModel.DataAnnotations.Schema;

#nullable disable

namespace Diadiabetes_App.model
{
    public partial class Notification
    {
        public long Id { get; set; }

        public long NotificationID { get; set; }
        

    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class Notification
    {
        public int NotificationId { get; set; }

        public string NotificationContent { get; set; }

        //Insert fk of training track here
        public int TrainingTrackId { get; set; }
/*        public TrainingTrack TrainingTracks { get; set; }*/
    }
}

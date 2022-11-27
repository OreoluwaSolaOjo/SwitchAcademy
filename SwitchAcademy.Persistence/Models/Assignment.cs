using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class Assignment
    {
        public int AssignmentId { get; set; }

        public string AssignmentGoogleDriveLink { get; set; }
        public string AssignmentGithubLink { get; set; }

        public string Others { get; set; }

        public int TrainingTrackId { get; set; }
        public TrainingTrack TrainingTracks { get; set; }

    }
}

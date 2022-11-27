using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class TrainingTrack
    {
        public int TrainingTrackId { get; set; }

        public string TrainingTrackName { get; set; }

        public ICollection<User> Users { get; set; } 
        public ICollection<Notification> Notifications { get; set; }

        public ICollection<QuestionsBank> QuestionsBanks { get; set; }
        
        public ICollection<Assignment> Assignments { get; set; } 
    }
}

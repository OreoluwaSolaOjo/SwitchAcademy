using SwitchAcademy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.DTOs
{
    public class GetTrainingTrackDto
    {
        public int TrainingTrackId { get; set; }

        public string TrainingTrackName { get; set; }

        public ICollection<GetUserDto> Users { get; set; }
        public ICollection<Notification> Notifications { get; set; }

        public ICollection<QuestionsBank> QuestionsBanks { get; set; }

        public ICollection<Assignment> Assignments { get; set; }
    }
}

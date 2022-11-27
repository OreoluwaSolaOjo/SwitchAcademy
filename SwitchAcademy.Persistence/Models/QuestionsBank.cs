using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class QuestionsBank
    { 
        public int QuestionsBankId { get; set; }

        [Column(TypeName = "nvarchar(250)")]
        public string QuestionContent { get; set; }

        [Column(TypeName ="nvarchar(150)")]
        public string option1 { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string option2 { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string option3 { get; set; }
        [Column(TypeName = "nvarchar(150)")]
        public string option4 { get; set; }
     
        public string Answer { get; set; }

        /* Insert training track foreign key here*/
        public int TrainingTrackId { get; set; }
    /*    public TrainingTrack TrainingTracks { get; set; }*/
    }
}

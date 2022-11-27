using SwitchAcademy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.DTOs
{
    public class GetUserDto
    {
        public int Id { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public string? Gender { get; set; }
        public string? Email { get; set; }

        public int TrainingTrackId { get; set; }

        public int Score { get; set; }
        
        public bool HasTakenExam { get; set; }
        public int TimeTaken { get; set; }
        public GetTrainingTrackDto TrainingTracks { get; set; }
        /*  public string? TrainingTrack { get; set; }*/
        public string? Degree { get; set; }
        public bool IsExperienced { get; set; }
        public bool IsCompletedNysc { get; set; }
    }
}

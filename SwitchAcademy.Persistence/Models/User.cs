using SwitchAcademy.Persistence.DTOs.Enums;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class User
    {
        public int Id { get; set; }
        public string? Email { get; set; }
        public byte[]? PasswordHash { get; set; }
        public byte[]? PasswordSalt { get; set; }
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderEnum Gender { get; set; }
       
       /* public TrainingTrackEnum TrainingTrack { get; set; }*/
        public DegreeEnums Degree { get; set; }
        public bool IsCompletedNysc { get; set; } = false;
        public bool IsExperienced { get; set; } = false;
        [JsonIgnore]
        public DateTime CreatedAt { get; set; } = DateTime.Now;

        public int? Score { get; set; }
        
        public bool HasTakenExam { get; set; }
        public int? TimeTaken { get; set; }
        //Insert fk of training track here
        public int TrainingTrackId { get; set; }
        public TrainingTrack TrainingTracks { get; set; }
    }
}

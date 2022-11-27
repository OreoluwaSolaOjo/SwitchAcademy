using SwitchAcademy.Persistence.DTOs.Enums;
using SwitchAcademy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.DTOs
{
    public class UpdateUserDto
    {
        public string? FirstName { get; set; }
        public string? LastName { get; set; }
        public GenderEnum Gender { get; set; }
        public string? Email { get; set; }
        public int TrainingTrackId { get; set; }
        public int Score { get; set; }
        [DefaultValue(false)]
        public bool HasTakenExam { get; set; } = false;
        public int TimeTaken { get; set; }
        public DegreeEnums Degree { get; set; }
        public bool IsExperienced { get; set; }
        public bool IsCompletedNysc { get; set; }
    }
}

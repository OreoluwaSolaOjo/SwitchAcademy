using SwitchAcademy.Persistence.DTOs.Enums;
using SwitchAcademy.Persistence.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.DTOs
{
    public class RegisterDto
    {
        [Required]
        [EmailAddress]
        public string? Email { get; set; }
        [Required]
        public string? Password { get; set; }
        [Required]
        public string? FirstName { get; set; }
        [Required]
        public string? LastName { get; set; }
        [Required]
        public GenderEnum Gender { get; set; }
        /* [Required]
         public TrainingTrackEnum TrainingTrack { get; set; }*/
        [Required]
        public int TrainingTrackId { get; set; }
        
        [Required]
        public DegreeEnums Degree { get; set; }
        [Required]
        public bool IsCompletedNysc { get; set; }
        [Required]
        public bool IsExperienced { get; set; }
    }
}

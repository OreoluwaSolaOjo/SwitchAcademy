using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Models
{
    public class DataContext: DbContext
    {
        public DataContext(DbContextOptions options) : base(options)
        {
        }


        public DbSet<User> Users { get; set; }
        public DbSet<TrainingTrack> TrainingTracks { get; set; }
        public DbSet<QuestionsBank> QuestionsBanks { get; set; }
        public DbSet<Notification> Notifications { get; set; }
    }
}

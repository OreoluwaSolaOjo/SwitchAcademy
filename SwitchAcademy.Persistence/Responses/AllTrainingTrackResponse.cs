using SwitchAcademy.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class AllTrainingTrackResponse<T>: DefaultResponse
    {
        public List<T>? TrainingTracks { get; set; }
    }
}
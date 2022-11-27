using SwitchAcademy.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class GetSingleTrainingTrackResponse<T> : DefaultResponse
    {
        public T? TrainingTrack { get; set; }
    }
}



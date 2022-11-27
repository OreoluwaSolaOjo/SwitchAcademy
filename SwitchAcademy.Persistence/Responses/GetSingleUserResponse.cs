using SwitchAcademy.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class GetSingleUserResponse<T> : DefaultResponse
    {
        public T? User { get; set; }
    }
}
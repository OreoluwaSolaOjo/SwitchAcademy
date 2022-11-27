using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class DefaultResponse
    {
        public bool IsSuccessful { get; set; } = false;
        public string? ResponseMessage { get; set; }
        public string ResponseCode { get; set; } = "119";
    }
}

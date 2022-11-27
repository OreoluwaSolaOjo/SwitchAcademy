using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class AllUsersResponse<T>: DefaultResponse
    {
        public List<T>? Users { get; set; }
    }
}

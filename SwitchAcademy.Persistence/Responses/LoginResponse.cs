using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Persistence.Responses
{
    public class LoginResponse : DefaultResponse
    {
        public string UserName { get; set; }
        public string Token { get; set; }
       public int Id { get; set; }
        public bool isAuthenticated { get; set; }
    }
}

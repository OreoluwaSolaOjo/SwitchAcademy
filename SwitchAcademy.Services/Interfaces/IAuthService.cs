using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Services.Interfaces
{
    public interface IAuthService
    {
        Task<LoginResponse> Login(LoginDto request);
        Task<DefaultResponse> Registration(RegisterDto request);
    }
}

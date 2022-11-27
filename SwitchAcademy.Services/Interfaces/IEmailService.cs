using SwitchAcademy.Persistence.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Services.Interfaces
{
    public interface IEmailService
    {
        Task SendEmail(SendEmailDto request);
    }
}

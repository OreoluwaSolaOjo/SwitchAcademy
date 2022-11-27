using Mailjet.Client.Resources;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Responses;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Services.Interfaces
{
    public interface IUserService
    {
        Task<AllUsersResponse<GetUserDto>> GetAllUsers();
        Task<GetSingleUserResponse<GetUserDto>> GetUserById(int Id);
        Task<GetSingleUserResponse<GetUserDto>> UpdateUser(int Id, UpdateUserDto request);


    }
}

using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.DTOs.Enums;
using SwitchAcademy.Persistence.GenericRepository;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Services.Implementations
{
    public class UserService : IUserService
    {
        private readonly DataContext _context;
        private readonly IEntityFrameworkRepository<User> _entityFrameworkRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;

        public UserService(DataContext context, IEntityFrameworkRepository<User> entityFrameworkRepository, ITokenService tokenService, IMapper mapper)
        {
            _context = context;
            _entityFrameworkRepository = entityFrameworkRepository;
            _tokenService = tokenService;
            _mapper = mapper;
        }
        public async Task<AllUsersResponse<GetUserDto>> GetAllUsers()
        {
            var response = new AllUsersResponse<GetUserDto>();
            try
            {
                //var users =  _entityFrameworkRepository.GetAll();
                var users = await _context.Users.ToListAsync();
                var mappedData = _mapper.Map<List<GetUserDto>>(users);

                response.IsSuccessful = true;
                response.ResponseCode = "0";
                response.ResponseMessage = "Successful";
                response.Users = mappedData;
                return response;

            }
            catch (Exception e)
            {
                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }

        }


        public async Task<GetSingleUserResponse<GetUserDto>> GetUserById(int Id)
        {
            var response = new GetSingleUserResponse<GetUserDto>();
            try
            {
                //var users =  _entityFrameworkRepository.GetAll();
                /*                var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);*/
                var users = await _context.Users.Include(x => x.TrainingTracks.Notifications).FirstOrDefaultAsync(x => x.Id == Id);
                var mappedData = _mapper.Map<GetUserDto>(users);

                response.IsSuccessful = true;
                response.ResponseCode = "0";
                response.ResponseMessage = "Successful";
                response.User = mappedData;
                return response;

            }
            catch (Exception e)
            {
                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }

        }

        public async Task<GetSingleUserResponse<GetUserDto>> UpdateUser(int Id, UpdateUserDto request)
        {
            var response = new GetSingleUserResponse<GetUserDto>();
            try
            {
                //var users =  _entityFrameworkRepository.GetAll();
                /*                var users = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);*/
                var user = await _context.Users.FirstOrDefaultAsync(x => x.Id == Id);
                if (user == null)
                {
                    response.ResponseCode = "1";
                    response.ResponseMessage = "User doesn't exist";
                    response.User = null;
                    return response;
                }

                var update = await UpdateUserSave(request, user);
                if (update == -1)
                {
                    response.ResponseCode = "1";
                    response.ResponseMessage = "Cannot Update User.. Contact Support";
                    response.User = null;
                    return response;
                }
                

                var users = await _context.Users.Include(x => x.TrainingTracks.Notifications).FirstOrDefaultAsync(x => x.Id == Id);
                var mappedData = _mapper.Map<GetUserDto>(users);

                response.IsSuccessful = true;
                response.ResponseCode = "0";
                response.ResponseMessage = "User Updated";
                response.User = mappedData;
                return response;
            }
            catch (Exception e)
            {
                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }

        }

        private async Task<int> UpdateUserSave(UpdateUserDto request, User user)
        {
            try
            {
                user.IsCompletedNysc = request.IsCompletedNysc;
                user.FirstName = request.FirstName;
                user.LastName = request.LastName;
                user.Gender = request.Gender;
                user.Email = request.Email;
                user.TrainingTrackId = request.TrainingTrackId;
                user.Score = request.Score;
                user.HasTakenExam = request.HasTakenExam;
                user.TimeTaken = request.TimeTaken;
                user.Degree = request.Degree;
                user.IsExperienced = request.IsExperienced;

                await _context.SaveChangesAsync();
                return 1;
            }
            catch (Exception e)
            {

                return -1;
            }
            
        }
    }


}

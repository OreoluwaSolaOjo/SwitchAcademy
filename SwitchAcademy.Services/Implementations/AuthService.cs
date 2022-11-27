using AutoMapper;
using Microsoft.EntityFrameworkCore;
using RestSharp;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.GenericRepository;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Linq;
using System.Reflection.Metadata;
using System.Security.Cryptography;
using System.Text;
using System.Threading.Tasks;

namespace SwitchAcademy.Services.Implementations
{
    public class AuthService : IAuthService
    {
        private readonly DataContext _context;
        private readonly IEntityFrameworkRepository<User> _entityFrameworkRepository;
        private readonly ITokenService _tokenService;
        private readonly IMapper _mapper;
        private readonly IEmailService _emailService;

        public AuthService(DataContext context, IEntityFrameworkRepository<User> entityFrameworkRepository, ITokenService tokenService, IMapper mapper, IEmailService emailService)
        {
            _context = context;
            _entityFrameworkRepository = entityFrameworkRepository;
            _tokenService = tokenService;
            _mapper = mapper;
            _emailService = emailService;
        }

        
        public async Task<DefaultResponse> Registration(RegisterDto request)
        {
            var response = new DefaultResponse();
            try
            {
                if (await UserExists(request.Email))
                {
                    response.ResponseCode = "1";
                    response.ResponseMessage = "Email already taken";
                    return response;
                }

                using var hmac = new HMACSHA512();

                var user = new User
                {
                    Email = request.Email.ToLower(),
                    PasswordHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password)),
                    PasswordSalt = hmac.Key,
                    Degree = request.Degree,
                    FirstName = request.FirstName,
                    Gender = request.Gender,
                    IsCompletedNysc = request.IsCompletedNysc,
                    LastName = request.FirstName,
                    IsExperienced = request.IsExperienced,
                    TrainingTrackId = request.TrainingTrackId
                };

                await _entityFrameworkRepository.AddAsync(user);
               /* var email = new SendEmailDto
                {
                    Subject = "Test From this side",
                    Body = $"Account {request.Email.ToLower()} has been created",
                    ToEmail = request.Email.ToLower()
                };*/
           /*     await _emailService.SendEmail(email);*/

                response.IsSuccessful = true;
                response.ResponseCode = "0";
                response.ResponseMessage = "Account Created";
                return response;

            }
            catch (Exception e)
            {

                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }

        }


        public async Task<LoginResponse> Login(LoginDto request)
        {
            var response = new LoginResponse();
            try
            {
                var user = await _context.Users.SingleOrDefaultAsync(x => x.Email == request.Email);

                if (user == null)
                {
                    response.ResponseCode = "1";
                    response.ResponseMessage = "Invalid Credentials";
                    return response;
                }
                using var hmac = new HMACSHA512(user.PasswordSalt);

                var computedHash = hmac.ComputeHash(Encoding.UTF8.GetBytes(request.Password));

                for (int i = 0; i < computedHash.Length; i++)
                {
                    if (computedHash[i] != user.PasswordHash[i])
                    {
                        response.ResponseCode = "1";
                        response.ResponseMessage = "Invalid Credentials";
                        return response;
                    }
                }
               
                response.IsSuccessful = true;
                response.ResponseCode = "0";
                response.ResponseMessage = "Successful";
                response.UserName = user.Email;
                response.Token = _tokenService.CreateToken(user);
              /*  var handler = new JwtSecurityTokenHandler();
                var decodedToken = handler.ReadJwtToken(response.Token);
                var claims = decodedToken.Claims.ToList();
                var userid = claims.Where(x => x.Type == "nam").Select(x => x.Value).FirstOrDefault();
                if (userid != null)
                    return userid;
                return claims.Where(x => x.Type == "client_id").Select(x => x.Value).FirstOrDefault();*/
           
                response.Id = GetUserId(response.Token);
                response.isAuthenticated = true;
             
                return response;
            }
            catch (Exception e)
            {

                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }
            

        }

        private int GetUserId(string token)
        {
            var id = (new JwtSecurityTokenHandler().ReadJwtToken(token))
              .Claims.First(c => c.Type == "nameid").Value;
            return Convert.ToInt32(id);
        }

        private async Task<bool> UserExists(string email)
        {
            return await _context.Users.AnyAsync(x => x.Email == email.ToLower());
        }
    }

    internal interface IRestResponse
    {
    }
}

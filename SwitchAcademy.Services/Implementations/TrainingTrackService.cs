using AutoMapper;
using Microsoft.EntityFrameworkCore;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Models;
using SwitchAcademy.Persistence.Responses;
using SwitchAcademy.Services.Interfaces;

namespace SwitchAcademy.Services.Implementations
{
  
    public class TrainingTrackService : ITrainingTrackService
    {
        private readonly DataContext _context;
        private readonly IMapper _mapper;

        public TrainingTrackService(DataContext context, IMapper mapper)
        {
            _context = context;
            _mapper = mapper;
        }
        public async Task<AllTrainingTrackResponse<GetTrainingTrackDto>> GetAllTrainingTracks()
        {
            var response = new AllTrainingTrackResponse<GetTrainingTrackDto>();
            try
            {
                var result = await _context.TrainingTracks
                    .Include(x => x.Users).Include(x => x.Notifications).Include(x => x.QuestionsBanks)
                    .Include(x => x.Assignments).ToListAsync();
                var mappedData = _mapper.Map<List<GetTrainingTrackDto>>(result);
                response.IsSuccessful = true;
                response.ResponseMessage = "Training Tracks Retrieved";
                response.ResponseCode = "0";
                response.TrainingTracks = mappedData;
                return response;

            }
            catch (Exception e)
            {
                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }


        }

        public async Task<GetSingleTrainingTrackResponse<GetTrainingTrackDto>> GetTrackById(int id)
        {
            var response = new GetSingleTrainingTrackResponse<GetTrainingTrackDto>();
            try
            {
                

                var result = await _context.TrainingTracks
                    .Include(x => x.Users).Include(x => x.Notifications).Include(x => x.QuestionsBanks)
                    .Include(x => x.Assignments).FirstOrDefaultAsync(x => x.TrainingTrackId == id);
                var mappedData = _mapper.Map<GetTrainingTrackDto>(result);
                response.IsSuccessful = true;
                response.ResponseMessage = "Training Tracks Retrieved";
                response.ResponseCode = "0";
                response.TrainingTrack = mappedData;
                return response;
            }
            catch (Exception e)
            {
                response.ResponseCode = "907";
                response.ResponseMessage = e.Message;
                return response;
            }

        }
    }
}
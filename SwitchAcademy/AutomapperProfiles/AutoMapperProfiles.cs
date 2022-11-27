using AutoMapper;
using SwitchAcademy.Persistence.DTOs;
using SwitchAcademy.Persistence.Models;

namespace SwitchAcademy.AutomapperProfiles
{
    public class AutoMapperProfiles : Profile
    {
        public AutoMapperProfiles()
        {
            CreateMap<User, GetUserDto>()
                .ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                .ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                .ForMember(dest => dest.TrainingTrackId, opt => opt.MapFrom(src => src.TrainingTrackId))
                .ReverseMap();

            CreateMap<TrainingTrack, GetTrainingTrackDto>()
                //.ForMember(dest => dest.Gender, opt => opt.MapFrom(src => src.Gender))
                //.ForMember(dest => dest.Degree, opt => opt.MapFrom(src => src.Degree))
                //.ForMember(dest => dest.TrainingTrackId, opt => opt.MapFrom(src => src.TrainingTrackId))
                .ReverseMap();
        }
    }
}

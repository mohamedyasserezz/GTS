using AutoMapper;
using GTS.TaskManagement.Domain.Entites;
using GTS.TaskManagement.Shared.Models;

namespace GTS.Application.Mapping
{
    public class MappingProfile : Profile
    {
        public MappingProfile()
        {
            CreateMap<ToDo, ToDoResponse>()
                .ForMember(dest => dest.Id, otp => otp.MapFrom(src => src.Id.ToString()))
                .ForMember(dest => dest.Status, otp => otp.MapFrom(src => src.Status.ToString()))
                .ForMember(dest => dest.Priority, otp => otp.MapFrom(src => src.Priority.ToString()));
                
        }
    }
}

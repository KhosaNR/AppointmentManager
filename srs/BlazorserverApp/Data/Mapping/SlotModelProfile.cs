using Application.DTOs;
using AutoMapper;

namespace BlazorserverApp.Data.Mapping
{
    internal class SlotModelProfile: Profile
    {
        public SlotModelProfile()
        {
            CreateMap<SlotDto, SlotModel>()
                .ForMember(dest => dest.SlotDate,
                opt => opt.MapFrom(src => src.SlotDate))
                .ReverseMap();
        }
    }
}

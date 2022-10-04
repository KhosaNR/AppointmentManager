using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs.Mapping
{
    internal class SlotProfile: Profile
    {
        public SlotProfile()
        {
            CreateMap<SlotDto, Domain.Entities.Slot>()
                .ForMember(dest => dest.AppointmentDate,
                opt => opt.MapFrom(src => src.SlotDate))
                .ReverseMap();
        }
    }
}

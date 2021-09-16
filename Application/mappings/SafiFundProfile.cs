using Application.dtos;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiFundProfile : Profile
    {
     
        public SafiFundProfile()
        {

            CreateMap<SafiFund, GetSafiFundRequirementByIdDto>()
                .ForMember(dest => dest.safiFundPersonTypeDtos, o => o.MapFrom(src => src.safiFundPersonTypes));
        }

        


    }
}

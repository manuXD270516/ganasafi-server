using Application.dtos;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiFundPersonTypeProfile : Profile
    {
        public SafiFundPersonTypeProfile()
        {
            CreateMap<SafiFundPersonType, SafiFundPersonTypeDto>()
                .ForMember(dest => dest.safiFundPersonTypeId, opt => opt.MapFrom(src => src.id))
                .ForMember(dest => dest.safiFundPersonTypeRequirementDtos, opt => opt.MapFrom(src => src.clsRequirements))
                .ForMember(dest => dest.codPersonType, opt => opt.MapFrom(src => src.clsPersonType.abbreviation))
                .ForMember(dest => dest.shortDescription, opt => opt.MapFrom(src => src.clsPersonType.shortDescription))
                .ForMember(dest => dest.description, opt => opt.MapFrom(src => src.clsPersonType.description));
        }
        }
}

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
                .ForMember(src => src.safiFundPersonTypeId, opt => opt.MapFrom(org => org.id))
                .ForMember(src => src.safiFundPersonTypeRequirementDtos, opt => opt.MapFrom(org => org.clsRequirements))
                .ForMember(src => src.codPersonType, opt => opt.MapFrom(org => org.clsPersonType.abbreviation))
                .ForMember(src => src.shortDescription, opt => opt.MapFrom(org => org.clsPersonType.shortDescription))
                .ForMember(src => src.description, opt => opt.MapFrom(org => org.clsPersonType.description));
        }
        }
}

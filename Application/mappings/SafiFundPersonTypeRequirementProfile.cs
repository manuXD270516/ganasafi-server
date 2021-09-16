using Application.dtos;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiFundPersonTypeRequirementProfile : Profile
    {

        public SafiFundPersonTypeRequirementProfile()
        {
            CreateMap<Classifier, SafiFundPersonTypeRequirementDto>()
                .ForMember(src => src.description, opt => opt.MapFrom(org => org.description))
                .ForMember(src => src.shortDescription, opt => opt.MapFrom(org => org.shortDescription));
               
            //CreateMap<List<SafiFundRequirement>, List<SafiFundRequirementDto>>();
        }
    }
}

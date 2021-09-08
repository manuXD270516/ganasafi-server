using Application.dtos;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiFundRequirementProfile : Profile
    {

        public SafiFundRequirementProfile()
        {
            CreateMap<SafiFundRequirement, SafiFundRequirementDto>();
            //CreateMap<List<SafiFundRequirement>, List<SafiFundRequirementDto>>();
        }
    }
}

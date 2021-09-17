using Application.dtos;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiContractProfile: Profile
    {

        public SafiContractProfile()
        {
            CreateMap<SafiContract, GetSafiContractDto>()
                .ForMember(dest => dest.safiContractId, opt => opt.MapFrom(src => src.id));
        }
    }
}

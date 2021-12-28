using Application.dtos;
using Application.features.safiDataTransfer.commands;
using Application.features.safiDataTransfer.commands.createSafiDataTransfer;
using AutoMapper;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.mappings
{
    public class SafiDataTransferProfile : Profile
    {
        public SafiDataTransferProfile()
        {
            CreateMap<CreateSafiDataTransferCommand, SafiDataTransfer>();
            CreateMap<UpdateSafiDataTransferCommand, SafiDataTransfer>();

            CreateMap<SafiDataTransfer, SafiDataTransferDto>();
            CreateMap<List<SafiDataTransfer>, List<SafiDataTransferDto>>();


        }
    }
}

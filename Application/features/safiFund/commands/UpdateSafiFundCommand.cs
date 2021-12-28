using Application.interfaces;
using Application.wrappers;
using AutoMapper;
using Domain.entities;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiFund.commands
{
    public class UpdateSafiFundCommand : IRequest<Response<bool>>
    {

        public int id { get; set; }
        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public string currency { get; set; }
        public double minimunOpeningAmount { get; set; }
        public string image { get; set; }
        public string permittedRescues { get; set; }
        public string target { get; set; }


        public void mergeFieldsWithCommand(ref SafiFund entityBase)
        {
            if (this != null)
            {
                entityBase.code = code;
                entityBase.title= title;
                entityBase.description = description;
                entityBase.shortDescription = shortDescription;
                entityBase.currency = currency;
                entityBase.minimunOpeningAmount = minimunOpeningAmount;
                entityBase.image = image;
                entityBase.permittedRescues = permittedRescues;
                entityBase.target = target;
            }
        }


        public class UpdateSafiFundCommandHandler : IRequestHandler<UpdateSafiFundCommand, Response<bool>>
        {

            private readonly IUnitOfWork _unitOfWork;
            private readonly IMapper _mapper;

            public Task<Response<bool>> Handle(UpdateSafiFundCommand request, CancellationToken cancellationToken)
            {
                throw new NotImplementedException();
            }
        }
    }
}

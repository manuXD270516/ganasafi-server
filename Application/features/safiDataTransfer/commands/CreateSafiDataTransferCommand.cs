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

namespace Application.features.safiDataTransfer.commands.createSafiDataTransfer
{
    public class CreateSafiDataTransferCommand : IRequest<Response<int>>
    {
        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }

        public int idClsCurrencyTransfer { get; set; }
    }

    public class CreateSafiDataTransferCommandHandler : IRequestHandler<CreateSafiDataTransferCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSafiDataTransferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreateSafiDataTransferCommand request, CancellationToken cancellationToken)
        {
            var safiDataTransferForCreate = _mapper.Map<SafiDataTransfer>(request);
            var result = await _unitOfWork._safiDataTransferRepository.CreateAsync(safiDataTransferForCreate);

            return new Response<int>
            {
                data = result,
                message = "SAFI Data Transfer was created succcessfully",
                successed = true
            };
        }
    }
}

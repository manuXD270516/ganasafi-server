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

namespace Application.features.safiContract.commands.createSafiContractCmd
{
    public class CreateSafiContractCommand : IRequest<Response<int>>
    {
        // fields for create
        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }


    }

    public class CreateSafiContractCommandHandler : IRequestHandler<CreateSafiContractCommand, Response<int>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public CreateSafiContractCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<Response<int>> Handle(CreateSafiContractCommand request, CancellationToken cancellationToken)
        {
            var result = await _unitOfWork._safiDataTransferRepository
                .CreateAsync(_mapper.Map<SafiDataTransfer>(request));
            return new Response<int>
            {
                data = result,
                message = "SAFI contract was created succcessfully",
                successed = true
            };
        }
    }
}

using Application.interfaces;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiDataTransfer.commands
{
    public class DeleteSafiDataTransferCommand : IRequest<Response<bool>>
    {
        public int id { get; set; }

    }

    public class DeleteSafiDataTransferCommandHandler : IRequestHandler<DeleteSafiDataTransferCommand, Response<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public DeleteSafiDataTransferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(DeleteSafiDataTransferCommand request, CancellationToken cancellationToken)
        {

            var result  = await _unitOfWork._safiDataTransferRepository.DeleteAsync(request.id);
            return new Response<bool>
            {
                message = $"SAFI Data Transfer with Id: {request.id} deleted successfully"
            };
        
        }
    }
}

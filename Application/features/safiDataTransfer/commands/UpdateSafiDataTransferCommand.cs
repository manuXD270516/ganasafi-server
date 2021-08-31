using Application.exceptions;
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

namespace Application.features.safiDataTransfer.commands
{
    public class UpdateSafiDataTransferCommand : IRequest<Response<bool>>
    {
        public int id { get; set; }

        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }


        public void mergeFieldsWithCommand(ref SafiDataTransfer entityBase)
        {
            if (this != null)
            {
                entityBase.accountNumber = accountNumber;
                entityBase.headline = headline;
                entityBase.description = description;
            }
        }
    }

    public class UpdateSafiDataTransferCommandHandler : IRequestHandler<UpdateSafiDataTransferCommand, Response<bool>>
    {

        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public UpdateSafiDataTransferCommandHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(UpdateSafiDataTransferCommand request, CancellationToken cancellationToken)
        {
            var safiDataTransferForUpdate = await _unitOfWork._safiDataTransferRepository.FindByIdAsync(request.id);
            if (safiDataTransferForUpdate == null)
            {
                throw new ApiException($"Safi Data Transfer Id: {request.id} not found"); 
            }
            // apply mapper 
            request.mergeFieldsWithCommand(ref safiDataTransferForUpdate);

            var result = await _unitOfWork._safiDataTransferRepository.UpdateAsync(safiDataTransferForUpdate);
            
            return new Response<bool>
            {
                message = $"SAFI Data Transfer with Id: {request.id} updated successfully"
            };
        }



    }
}

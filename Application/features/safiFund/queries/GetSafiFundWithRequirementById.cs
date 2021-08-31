using Application.dtos;
using Application.interfaces;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiFund.queries
{
    public class GetSafiFundWithRequirementByIdQuery : IRequest<Response<GetSafiFundRequirementDto>>
    {
        public int id { get; set; }

    }

    public class GetSafiFundWithRequirementByIdQueryHanderl : IRequestHandler<GetSafiFundWithRequirementByIdQuery, Response<GetSafiFundRequirementDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IMapper _mapper;

        public GetSafiFundWithRequirementByIdQueryHanderl(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GetSafiFundRequirementDto>> Handle(GetSafiFundWithRequirementByIdQuery request, CancellationToken cancellationToken)
        {
            var safiFundWithRequirementFind = await _unitOfWork._safiFundRequirementRepository.FindBySafiFundId(request.id);
            if (safiFundWithRequirementFind == null)
            {
                throw new KeyNotFoundException($"SAFI Fund Requirement not found with Id: {request.id}");
            }
            return new Response<GetSafiFundRequirementDto> { data = safiFundWithRequirementFind };
        }
    }
}

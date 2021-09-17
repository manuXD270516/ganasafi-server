using Application.dtos;
using Application.interfaces;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiFund.queries
{
    public class GetSafiFundByIdQuery : IRequest<Response<GetSafiFundRequirementByIdDto>>
    {
        public int id { get; set; }

        #region "Filter params"
        public string personTypeCode { get; set; }
        #endregion

    }

    public class GetSafiFundWithRequirementByIdQueryHandler : IRequestHandler<GetSafiFundByIdQuery, Response<GetSafiFundRequirementByIdDto>>
    {

        private readonly IUnitOfWork _unitOfWork;
        
        private readonly IMapper _mapper;

        public GetSafiFundWithRequirementByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<GetSafiFundRequirementByIdDto>> Handle(GetSafiFundByIdQuery request, CancellationToken cancellationToken)
        {
            var safiFundWithRequirementFind = await _unitOfWork._safiFundRepository.FindBySafiFundId(request.id, request.personTypeCode);
            if (safiFundWithRequirementFind == null)
            {
                throw new KeyNotFoundException($"SAFI Fund Requirement not found with Id: {request.id}");
            }
            // apply mapping 
            var result = _mapper.Map<GetSafiFundRequirementByIdDto>(safiFundWithRequirementFind);
            return new Response<GetSafiFundRequirementByIdDto> { data = result };
        }
    }
}

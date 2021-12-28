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

namespace Application.features.safiContract.queries
{
    public class GetSafiContractByParamsQuery : IRequest<Response<GetSafiContractDto>>
    {

        #region "Filter params"
        public int idFundPersonType { get; set; }
        
        #endregion
    }

    public class GetSafiContractByParamsQueryHandler : IRequestHandler<GetSafiContractByParamsQuery, Response<GetSafiContractDto>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public GetSafiContractByParamsQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        
        public async Task<Response<GetSafiContractDto>> Handle(GetSafiContractByParamsQuery request, CancellationToken cancellationToken)
        {
            var safiContractFind = await _unitOfWork._safiContractRepository.FindFirstOrDefault(e => e.idFundPersonType == request.idFundPersonType);
            if (safiContractFind == null)
            {
                throw new KeyNotFoundException($"SAFI Fund Requirement not found with SafiPersonTypeId : {request.idFundPersonType}");
            }
            // apply mapping 
            var result = _mapper.Map<GetSafiContractDto>(safiContractFind);

            return new Response<GetSafiContractDto> { data = result };
        }
    }
}

using Application.dtos;
using Application.interfaces;
using Application.parameters;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiFund.queries
{
    public class GetAllSafiFundWithRequirementQuery : IRequest<PageResponse<List<GetSafiFundRequirementDto>>>
    {
        #region "Pagination Params"
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        #endregion


        #region "Filter params"
        public string personTypeCode { get; set; }
        #endregion

        #region "Order Params"
        public string orderByDirection { get; set; }

        #endregion

    }

    public class GetAllSafiFundWithRequirementQueryHandler : IRequestHandler<GetAllSafiFundWithRequirementQuery, PageResponse<List<GetSafiFundRequirementDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;

        public GetAllSafiFundWithRequirementQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }


        public async Task<PageResponse<List<GetSafiFundRequirementDto>>> Handle(GetAllSafiFundWithRequirementQuery request, CancellationToken cancellationToken)
        {
            var pageableParam = new RequestParameter
           (
               pageNumber: request.pageNumber,
               pageSize: request.pageSize,
               orderByDirection: request.orderByDirection
           );

            var result = await _unitOfWork._safiFundRequirementRepository.FindAllRequirementCustom(
             pagination: pageableParam,
             filter: (f) => string.IsNullOrEmpty(request.personTypeCode) ? true : f.personTypeCode == request.personTypeCode,
             orderBy: (ord) => string.IsNullOrEmpty(pageableParam.orderByDirection) || pageableParam.orderByDirection.Equals("ASC")
                         ? ord.OrderBy(p => p.safiFundId)
                         : ord.OrderByDescending(p => p.safiFundId)
            );

            
            return new PageResponse<List<GetSafiFundRequirementDto>>(result.ToList(), request.pageNumber, request.pageSize);
        }
    }
}

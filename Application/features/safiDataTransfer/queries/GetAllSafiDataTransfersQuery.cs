using Application.dtos;
using Application.helpers;
using Application.interfaces;
using Application.parameters;
using Application.specifications;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiDataTransfer.queries
{
    public class GetAllSafiDataTransfersQuery : IRequest<PageResponse<List<SafiDataTransferDto>>>
    {
        #region "Pagination Params"
        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        #endregion


        #region "Filter params"
        public double accountNumber { get; set; }
        #endregion

        #region "Order Params"
        public string orderByDirection { get; set; }

        #endregion

    }

    public class GetAllSafiDataTransferQueryHandler : IRequestHandler<GetAllSafiDataTransfersQuery, PageResponse<List<SafiDataTransferDto>>>
    {

        private readonly IUnitOfWork _unitOfWork;

        private readonly IMapper _mapper;


        public GetAllSafiDataTransferQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<PageResponse<List<SafiDataTransferDto>>> Handle(GetAllSafiDataTransfersQuery request, CancellationToken cancellationToken)
        {
            var pageableParam = new RequestParameter
            (
                pageNumber: request.pageNumber,
                pageSize: request.pageSize,
                orderByDirection: request.orderByDirection
            );

            Dictionary<string, int> additionalPropsFromRequest = new Dictionary<string, int>();

            var result = await _unitOfWork._safiDataTransferRepository.FindAllAsync(
                additionalProps: additionalPropsFromRequest,
                pagination: pageableParam,
                filter: (f) => double.IsNaN(request.accountNumber) || request.accountNumber<=0 ? true : f.accountNumber == request.accountNumber,
                orderBy: (ord) => string.IsNullOrEmpty(pageableParam.orderByDirection) || pageableParam.orderByDirection.Equals("ASC")
                            ? ord.OrderBy(p => p.id)
                            : ord.OrderByDescending(p => p.id)
            );

            List<SafiDataTransferDto> mapperList = _mapper.Map<List<SafiDataTransferDto>>(result);

            return new PageResponse<List<SafiDataTransferDto>>(
                mapperList,
                request.pageNumber, 
                request.pageSize, 
                additionalPropsFromRequest[HelpersConstApplication.KEY_TOTAL_COUNT]
            ) ;
        }





        
    }
}

using Application.interfaces;
using Application.wrappers;
using AutoMapper;
using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Application.features.safiContract.queries
{
    public class ExampleQuery : IRequest<Response<bool>>
    {
        public int x { get; set; }
    }

    public class ExampleQueryHandler : IRequestHandler<ExampleQuery, Response<bool>>
    {
        private readonly IUnitOfWork _unitOfWork;
        private readonly IMapper _mapper;

        public ExampleQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            _unitOfWork = unitOfWork;
            _mapper = mapper;
        }

        public async Task<Response<bool>> Handle(ExampleQuery request, CancellationToken cancellationToken)
        {

            

            await _unitOfWork._safiContractRepository.FindFirstOrDefault(null);

            await _unitOfWork._safiFundRepository.CreateAsync(null);

            await _unitOfWork._safiDataTransferRepository.DeleteAsync(1);


            var x= new Response<bool>()
            {
                data = true
            };
            return x;
        }
    }
}

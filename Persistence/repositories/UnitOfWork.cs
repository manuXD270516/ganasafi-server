using Application.interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        public ISafiDataTransferRepository _safiDataTransferRepository { get; }

        public ISafiFundRepository _safiFundRepository { get; }

        public ISafiFundRequirementRepository _safiFundRequirementRepository { get; }

        public ISafiContractRepository _safiContractRepository { get; }


        public UnitOfWork(ISafiDataTransferRepository safiDataTransferRepository, ISafiFundRepository safiFundRepository, ISafiFundRequirementRepository safiFundRequirementRepository, ISafiContractRepository safiContractRepository)
        {
            _safiDataTransferRepository = safiDataTransferRepository;
            _safiFundRepository = safiFundRepository;
            _safiFundRequirementRepository = safiFundRequirementRepository;
            _safiContractRepository = safiContractRepository;
        }
    }
}

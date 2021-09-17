using System;
using System.Collections.Generic;
using System.Text;

namespace Application.interfaces
{
    public interface IUnitOfWork
    {
        ISafiDataTransferRepository _safiDataTransferRepository { get; }
        ISafiFundRepository _safiFundRepository { get; }
        ISafiFundRequirementRepository _safiFundRequirementRepository{ get; }
        ISafiContractRepository _safiContractRepository { get; }

    }
}

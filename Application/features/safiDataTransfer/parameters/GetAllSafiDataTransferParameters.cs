using Application.parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.features.safiDataTransfer.parameters
{
    public class GetAllSafiDataTransferParameters : RequestParameter
    {
        public double accountNumber { get; set; }

    }
}

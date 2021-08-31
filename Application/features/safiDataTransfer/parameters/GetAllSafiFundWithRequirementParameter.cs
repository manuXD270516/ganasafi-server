using Application.parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.features.safiDataTransfer.parameters
{
    public class GetAllSafiFundWithRequirementParameter : RequestParameter
    {
        public string personTypeCode { get; set; }
    }
}

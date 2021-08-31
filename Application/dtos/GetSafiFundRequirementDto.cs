using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class GetSafiFundRequirementDto
    {
        public int safiFundId { get; set; }
        public string safiFundCode { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public string currency { get; set; }
        public double minimunOpeningAmount { get; set; }
        public string image { get; set; }
        public string permittedRescues { get; set; }
        public string target { get; set; }

        public string descFundRequirement { get; set; }
        public string personTypeCode { get; set; }


    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class GetSafiFundRequirementByIdDto
    {

        public string code { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string shortDescription { get; set; }
        public string currency { get; set; }
        public double minimunOpeningRequest { get; set; }
        public string image { get; set; }
        public string permitedRescues { get; set; }
        public string target { get; set; }

        public List<SafiFundRequirementDto> safiFundRequirements { get; set; }
    }
}

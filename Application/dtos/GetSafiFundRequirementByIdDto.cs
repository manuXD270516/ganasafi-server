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
        public string permittedRescues { get; set; }
        public string target { get; set; }

        public List<SafiFundPersonTypeDto> safiFundPersonTypeDtos {get; set; }
        //public List<SafiFundPersonTypeRequirementDto> safiFundRequirements { get; set; }
    }
}

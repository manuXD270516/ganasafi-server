using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class SafiFundPersonTypeDto
    {

        public int safiFundPersonTypeId { get; set; }

        public string codPersonType { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }

        public List<SafiFundPersonTypeRequirementDto> safiFundPersonTypeRequirementDtos { get; set; }
        

    }
}

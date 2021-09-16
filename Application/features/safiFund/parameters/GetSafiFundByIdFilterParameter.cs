using Application.parameters;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.features.safiFund.parameters
{
    public class GetSafiFundBydIdFilterParameter : RequestParameter
    {
        public string personTypeCode { get; set; }
    }
}

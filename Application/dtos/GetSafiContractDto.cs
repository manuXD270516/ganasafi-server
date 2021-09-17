using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class GetSafiContractDto
    {
        public int safiContractId { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string language { get; set; }
        public string url { get; set; }
    }
}

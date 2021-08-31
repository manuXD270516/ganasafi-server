using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class UpdateSafiDataTransferDto
    {

        public int id { get; set; }

        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }
    }
}

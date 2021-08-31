using System;
using System.Collections.Generic;
using System.Text;

namespace Application.dtos
{
    public class SafiDataTransferDto
    {
        public int id { get; set; }

        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }

        public DateTime? registrationDate { get; set; }

        public DateTime? modificationDate { get; set; }
    }
}

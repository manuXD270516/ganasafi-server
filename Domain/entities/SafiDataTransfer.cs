using Dapper.Contrib.Extensions;
using static Domain.helpers.HelpersDatabase;
using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_DATA_TRANSFER)]
    public class SafiDataTransfer: AuditableBaseEntity
    {

        public double accountNumber { get; set; }

        public string headline { get; set; }

        public string description { get; set; }
  
        

    }
}

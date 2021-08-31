using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;


namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_FUND)]
    public class SafiFund : AuditableBaseEntity
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

    }
}

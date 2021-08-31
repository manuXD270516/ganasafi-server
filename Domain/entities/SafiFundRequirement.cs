using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_FUND_REQUIREMENT)]
    public class SafiFundRequirement : AuditableBaseEntity
    {

        public SafiFund safiFund { get; set; }
        public string idPersonType { get; set; }
        public string description { get; set; }

    }
}

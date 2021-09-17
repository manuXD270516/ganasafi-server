using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_FUND_PERSON_TYPE_REQUIREMENT)]
    public class SafiFundPersonTypeRequirement : AuditableBaseEntity
    {

        #region "Relationships outgoing"
        
        public SafiFundPersonType safiFundPersonType { get; set; }
        public Classifier clsRequirement{ get; set; }

        #endregion

       
    }
}

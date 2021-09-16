using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_FUND_PERSON_TYPE)]
    public class SafiFundPersonType : AuditableBaseEntity
    {

        #region "Relationships ingoing"
        public int id { get; set; }

        // deprecated
        public List<SafiFundPersonTypeRequirement> safiFundPersonTypeRequirements { get; set; }


        public List<Classifier> clsRequirements { get; set; }

        #endregion

        #region "Relationship outgoing"

        public SafiFund safiFund{ get; set; }
        public Classifier clsPersonType { get; set; }


        #endregion

        public SafiFundPersonType()
        {
            clsRequirements = new List<Classifier>();
        }

    }
}

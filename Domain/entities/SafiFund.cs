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
        public double minimunOpeningAmount { get; set; }
        public string image { get; set; }
        public string permittedRescues { get; set; }
        public string target { get; set; }

        #region "Relationships ingoing"

        public SafiDataTransfer safiDataTransfer { get; set; }

        #endregion

        #region "Relationship outgoing"

        public  List<SafiFundPersonType> safiFundPersonTypes { get; set; }

        #endregion

        //public override int GetHashCode() => id.GetHashCode();  

        public SafiFund()
        {
            safiFundPersonTypes = new List<SafiFundPersonType>();
        }


    }
}

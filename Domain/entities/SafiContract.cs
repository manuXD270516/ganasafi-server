using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;
using System.Text.Json.Serialization;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_CONTRACT)]
    public class SafiContract : AuditableBaseEntity
    {
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string language { get; set; }
        public string url { get; set; }

        #region "Relationships outgoing"

        public int idFundPersonType { get; set; }

        public SafiFundPersonType safiFundPersonType { get; set; }

        #endregion

    }
}

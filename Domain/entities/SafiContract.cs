using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_CONTRACT)]
    public class SafiContract
    {
        public int id { get; set; }
        public string title { get; set; }
        public string description { get; set; }
        public string content { get; set; }
        public string language { get; set; }
        public string url { get; set; }

        #region "Relationships outgoing"

        public SafiFundPersonType safiFundPersonType { get; set; }

        #endregion

    }
}

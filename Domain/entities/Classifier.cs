using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json.Serialization;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_CLASSIFIER)]
    public class Classifier : AuditableBaseEntity
    {
		public int id { get; set; }
		public string code { get; set; }
		public string shortDescription { get; set; }
		public string description { get; set; }
		public string abbreviation { get; set; }
		public string otherValue { get; set; }

        #region "Relationship outgoing"
        public ClassifierType classifierType { get; set; }
        
        #endregion

        #region "Relationship ingoing"
        
        [JsonIgnore]
        public List<Classifier> classifiers { get; set; }

        public List<SafiFundPersonType> safiFundPersonTypes { get; set; }

        #endregion

        public Classifier()
        {
            safiFundPersonTypes = new List<SafiFundPersonType>();
        }




    }
}

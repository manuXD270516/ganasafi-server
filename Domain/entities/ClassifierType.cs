using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_CLASSIFIER_TYPE)]
    public class ClassifierType
    {
        public int id { get; set; }
        public string code { get; set; }
        public string shortDescription { get; set; }
        public string description { get; set; }
        public string abbreviation { get; set; }


        #region "Relationship outgoing"
        
        #endregion

        #region "Relationship ingoing"

        public List<ClassifierType> classifierTypes{ get; set; }

        #endregion


    }


}

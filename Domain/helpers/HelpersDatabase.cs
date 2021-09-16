using System;
using System.Collections.Generic;
using System.Text;

namespace Domain.helpers
{
    public static class HelpersDatabase
    {
        #region "Schemas database"
        public const string SCHEMA_NAME_GANADERO = "GANADERO";

        #endregion


        #region "Tables database"   
        public const string TABLE_NAME_CLASSIFIER = SCHEMA_NAME_GANADERO + "." + "Classifier";
        public const string TABLE_NAME_CLASSIFIER_TYPE = SCHEMA_NAME_GANADERO + "." + "ClassifierType";

        public const string TABLE_NAME_SAFI_DATA_TRANSFER = SCHEMA_NAME_GANADERO + "." + "SafiDataTransfer";
        public const string TABLE_NAME_SAFI_FUND = SCHEMA_NAME_GANADERO + "." + "SafiFund";
        public const string TABLE_NAME_SAFI_FUND_PERSON_TYPE = SCHEMA_NAME_GANADERO + "." + "SafiFundPersonType";
        public const string TABLE_NAME_SAFI_CONTRACT = SCHEMA_NAME_GANADERO + "." + "SafiContract";
        public const string TABLE_NAME_SAFI_FUND_PERSON_TYPE_REQUIREMENT = SCHEMA_NAME_GANADERO + "." + "SafiFundPersonTypeRequirement";
        public const string TABLE_NAME_SAFI_ACCOUNT_CREATED = SCHEMA_NAME_GANADERO + "." + "SafiAccountCreated";

        #endregion

        public const int ID_FOR_CREATE = 0;

    }
}

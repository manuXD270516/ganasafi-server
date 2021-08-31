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
        public const string TABLE_NAME_SAFI_DATA_TRANSFER = SCHEMA_NAME_GANADERO + "." + "SafiDataTransfer";
        public const string TABLE_NAME_SAFI_FUND = SCHEMA_NAME_GANADERO + "." + "SafiFund";
        public const string TABLE_NAME_SAFI_FUND_REQUIREMENT = SCHEMA_NAME_GANADERO + "." + "SafiFundRequirement";

        #endregion

        public const int ID_FOR_CREATE = 0;

    }
}

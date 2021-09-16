using Dapper.Contrib.Extensions;
using System;
using System.Collections.Generic;
using System.Text;
using static Domain.helpers.HelpersDatabase;

namespace Domain.entities
{
    [Table(TABLE_NAME_SAFI_ACCOUNT_CREATED)]
    public class SafiAccountCreated
    {
		public int id { get; set; }
		public double personNumber { get; set; }
		public double originAccount { get; set; }
		public double destinationAccount { get; set; }
		public double amount { get; set; }
		public string email { get; set; }
		public double idPayment { get; set; }
		public string idTopazTransfer { get; set; }
		public string errorMessage { get; set; }


		#region "Relationships outgoing"

		public SafiFundPersonType safiFundPersonType { get; set; }
		
		#endregion



	}
}

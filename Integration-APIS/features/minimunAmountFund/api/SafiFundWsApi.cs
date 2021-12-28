using RestSharp.Deserializers;
using Shared.interfaces;
using Shared.services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_APIS.features.minimunAmountFund.api
{
    public class SafiFundWsApi : BaseClient
    {

        
        public SafiFundWsApi(ICacheService cache, IDeserializer serializer, IErrorLogger errorLogger) 
            : base(cache, serializer, errorLogger, "")
        {
        }
    }
}

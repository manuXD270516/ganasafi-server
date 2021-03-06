using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Integration_APIS.features.minimunAmountFund.dtos
{
    public class SafiFundWsDto
    {
        public List<Item> items { get; set; }
        public int count { get; set; }
        public bool hasMore { get; set; }
        public int limit { get; set; }
        public int offset { get; set; }
        public List<Link> links { get; set; }
    }

    public class Link
    {
        public string rel { get; set; }
        public string href { get; set; }
        public string name { get; set; }
        public string kind { get; set; }
    }

    public class Item
    {
        public string Fondo { get; set; }
        public string Moneda { get; set; }
        public int Monto { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales_and_Finance.Models
{
    public class Sale
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Item { get; set; }

        public string Unit { get; set; }

        public string UnitCost { get; set; }

        public string Address { get; set; }
    }
}
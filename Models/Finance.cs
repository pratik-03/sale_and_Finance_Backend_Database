using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace Sales_and_Finance.Models
{
    public class Finance
    {
        public int Id { get; set; }

        public string Date { get; set; }

        public string Party { get; set; }

        public string Debit { get; set; }

        public string Credit { get; set; }

        public string Balance { get; set; }

    }
}
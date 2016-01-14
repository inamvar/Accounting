using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Models.Common
{
    public class Currency
    {
        public int Id { get; set; }
        public string Country { get; set; }
        public string CurrencyName { get; set; }
        public string Sign { get; set; }
        public int Rate { get; set; }
    }
}

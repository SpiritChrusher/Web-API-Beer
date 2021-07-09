using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.Linq;
using System.Threading.Tasks;

namespace WebAPI5.Models
{
    public class Beers
    {
        public long Id { get; set; }
        public string name { get; set; }

        public decimal alcohol { get; set; }

        public IEnumerable<string> taste { get; set; }

        public string origin { get; set; }

        public IEnumerable<string> type { get; set; }

        public string manufacturer { get; set; }

        public string consumption { get; set; }

        public int price { get; set; }

        public decimal quality { get; set; }

        public IEnumerable<string> acquisition { get; set; }

        public decimal packformat { get; set; }
    }
}

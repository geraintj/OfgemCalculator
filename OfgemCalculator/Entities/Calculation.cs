using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OfgemCalculator.Entities
{
    public class Calculation
    {
        public Guid Id { get; set; }
        public string First { get; set; }
        public string Second { get; set; }
        public Operation Operation { get; set; }
        public string Result { get; set; }
        public string ClientIp { get; set; }
    }
}

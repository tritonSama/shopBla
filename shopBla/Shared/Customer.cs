using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace shopBla.Shared
{
    public class Customer
    {
        public int id { get; set; }
        public string firstName { get; set; } = string.Empty;
        public string lastName { get; set; } = string.Empty;
        public string fullName { get; set; } = string.Empty;
    }
}

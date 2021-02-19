using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_EF.Models
{
    public class SuperMarket
    {
        public int Id { get; set; }
        public string Name { get; set; }
        public string Address { get; set; }

        List<Order> Orders { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_EF.Models
{
    public class Order
    {
        public int Id { get; set; }

        public int CustomerId { get; set; }
        public Customer Customer { get; set; }

        public int SuperMarketId { get; set; }
        public SuperMarket SuperMarket { get; set; }

        public DateTime Order_date { get; set; }
    }
}

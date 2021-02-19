using Hello_EF.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_EF.ViewModels
{
    public class OrderViewModel
    {
        public Order Order { get; set; }
        public OrderDetails OrderDetails { get; set; }
    }
}

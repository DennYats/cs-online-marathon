using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using System.ComponentModel.DataAnnotations;

namespace TaskAuthenticationAuthorization.Models
{
    public class Order
    {
        public int Id { get; set; }
        
        [DataType(DataType.Date)]
        [DisplayFormat(DataFormatString = "{0:yyyy-MM-dd}", ApplyFormatInEditMode = true)]
        public DateTime OrderDate { get; set; }
        public string UserId { get; set; }
        
        public int SuperMarketId { get; set; }

        public User User { get; set; }
        
        public SuperMarket SuperMarket { get; set; }
        public ICollection<OrderDetail> OrderDetails { get; set; }
    }
}

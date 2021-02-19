using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace TaskAuthenticationAuthorization.Models
{
    public enum Discount
    {
        O, R, V
    }
    public class User : IdentityUser
    {

        public string FirstName { get; set; }
        public string LastName { get; set; }
        public string Address { get; set; }
        public int Year { get; set; }

        public Discount? Discount { get; set; }
        public ICollection<Order> Orders { get; set; }
    }
}

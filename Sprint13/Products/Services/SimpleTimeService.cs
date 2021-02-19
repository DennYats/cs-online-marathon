using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public class SimpleTimeService : ITimeService
    {
        public DateTime GetTimeForTomorrow() =>
            DateTime.Today.AddDays(1);
    }
}
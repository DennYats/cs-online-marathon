using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Products.Services
{
    public interface ITimeService
    {
        DateTime GetTimeForTomorrow();
    }
}

using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace Hello_EF.Services
{
    public static class ServiceProvider
    {
        public static void AddSampleData(this IServiceCollection services) =>
            services.AddTransient<SampleData>();
    }
}

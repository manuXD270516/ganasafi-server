using Application.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Shared.services;
using System;
using System.Collections.Generic;
using System.Text;

namespace Shared
{
    public static class ServicesRegistration
    {
        public static void AddSharedInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {

            services.AddTransient<IDateTimeService, DateTimeService>();
        }

    }
}

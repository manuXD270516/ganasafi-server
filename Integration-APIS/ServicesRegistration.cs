using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using System;

namespace Integration_APIS
{
    public static class ServicesRegistration
    {

        public static void AddIntegrationApisInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Dependencies" 
            /*services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISafiDataTransferRepository, SafiDataTransferRepository>();
            services.AddTransient<ISafiFundRepository, SafiFundRepository>();
            services.AddTransient<ISafiFundRequirementRepository, SafiFundRequirementRepository>();
            services.AddTransient<ISafiContractRepository, SaficontractRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();*/

            #endregion
        }
    }
}

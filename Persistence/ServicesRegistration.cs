using Application.interfaces;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;
using Persistence.options;
using Persistence.repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence
{
    public static class ServicesRegistration
    {

        public static void AddPersistenceInfrastructure(this IServiceCollection services, IConfiguration configuration)
        {
            #region "Settings Database"
            var databaseSettings = new DatabaseSettings();
            configuration.Bind(nameof(DatabaseSettings), databaseSettings);
            services.AddSingleton(databaseSettings);
            #endregion

            #region "Repositories" 
            services.AddTransient(typeof(IRepository<>), typeof(Repository<>));
            services.AddTransient<ISafiDataTransferRepository, SafiDataTransferRepository>();
            services.AddTransient<ISafiFundRepository, SafiFundRepository>();
            services.AddTransient<ISafiFundRequirementRepository, SafiFundRequirementRepository>();
            services.AddTransient<ISafiContractRepository, SaficontractRepository>();

            services.AddTransient<IUnitOfWork, UnitOfWork>();

            #endregion
        }
    }
}

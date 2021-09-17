using Application.interfaces;
using Domain.entities;
using Persistence.options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.repositories
{
    public class SaficontractRepository : Repository<SafiContract>, ISafiContractRepository
    {
        public SaficontractRepository(DatabaseSettings dbSettings) : base(dbSettings)
        {
        }


    }
}

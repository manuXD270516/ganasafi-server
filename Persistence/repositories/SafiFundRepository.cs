using Application.interfaces;
using Domain.entities;
using Persistence.options;
using System;
using System.Collections.Generic;
using System.Text;

namespace Persistence.repositories
{
    public class SafiFundRepository : Repository<SafiFund>, ISafiFundRepository
    {
        public SafiFundRepository(DatabaseSettings dbSettings) : base(dbSettings)
        {
        }
    }
}

using Application.dtos;
using Application.helpers;
using Application.interfaces;
using Application.parameters;
using Dapper;
using Domain.entities;
using Persistence.options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Persistence.repositories
{
    public class SafiFundRequirementRepository : Repository<SafiFundRequirement>, ISafiFundRequirementRepository
    {
        public SafiFundRequirementRepository(DatabaseSettings dbSettings) : base(dbSettings)
        {
        }

        
    }
}

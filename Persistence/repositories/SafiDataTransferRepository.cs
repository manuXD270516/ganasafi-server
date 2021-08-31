using Application.interfaces;
using Domain.entities;
using Persistence.options;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Dapper;

namespace Persistence.repositories
{
    public class SafiDataTransferRepository : Repository<SafiDataTransfer>, ISafiDataTransferRepository
    {
        public SafiDataTransferRepository(DatabaseSettings dbSettings) : base(dbSettings)
        {
        }

         
    }
}

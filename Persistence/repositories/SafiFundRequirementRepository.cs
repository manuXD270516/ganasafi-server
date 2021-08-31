using Application.dtos;
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

        public async Task<IQueryable<GetSafiFundRequirementDto>> FindAllRequirementCustom(
            Expression<Func<GetSafiFundRequirementDto, bool>> filter = null,
            Func<IQueryable<GetSafiFundRequirementDto>, IOrderedQueryable<GetSafiFundRequirementDto>> orderBy = null, 
            RequestParameter pagination = null)
        {

            var sql = @"select v.* 
                        from ganadero.vw_GetSafiFundWithRequirementAssociate v ";
            //var parameters = new { codPersonTypeId =1 };
            var safiFoundCollection = (await DbConnection.QueryAsync<GetSafiFundRequirementDto>(sql, null))
                .AsQueryable();

            if (pagination != null)
            {
                int pageNumber = pagination.pageNumber, pageSize = pagination.pageSize;
                safiFoundCollection = safiFoundCollection.Skip((pageNumber - 1) * pageSize)
                    .Take(pageSize);
            }
            if (filter != null)
            {
                safiFoundCollection = safiFoundCollection.Where(filter);
            }
            if (orderBy != null)
            {
                safiFoundCollection = orderBy(safiFoundCollection);
            }
            return safiFoundCollection; 

        }

        public async Task<GetSafiFundRequirementDto> FindBySafiFundId(int safiFundId)
        {
           var sql = "select v.* from ganadero.vw_GetSafiFundWithRequirementAssociate v where v.\"safiFundId\" = @safiFoundId fetch first row only";
           var parameters = new { safiFoundId = safiFundId };
            var safiFoundCollection = (await DbConnection.QueryAsync<GetSafiFundRequirementDto>(sql, parameters))
                    .FirstOrDefault();
            return safiFoundCollection;
        }

        public Task<GetSafiFundRequirementDto> FindFirstOrDefault(Expression<Func<GetSafiFundRequirementDto, bool>> filter = null)
        {
            return null;
        }
    }
}

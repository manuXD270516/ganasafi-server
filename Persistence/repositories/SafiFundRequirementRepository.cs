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

        public async Task<IQueryable<GetSafiFundRequirementDto>> FindAllRequirementCustom(
            Dictionary<string, int> additionalProps,
            Expression<Func<GetSafiFundRequirementDto, bool>> filter = null,
            Func<IQueryable<GetSafiFundRequirementDto>, IOrderedQueryable<GetSafiFundRequirementDto>> orderBy = null,
            RequestParameter pagination = null)
        {

            var sql = @"select v.* 
                        from ganadero.vw_GetSafiFundWithRequirementAssociate v ";
            //var parameters = new { codPersonTypeId =1 };
            var safiFoundCollection = (await DbConnection.QueryAsync<GetSafiFundRequirementDto>(sql, null))
                .AsQueryable();

            additionalProps[HelpersConstApplication.KEY_TOTAL_COUNT] = safiFoundCollection.Count();

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

        public async Task<SafiFund> FindBySafiFundId(int safiFundId)
        {

            var sql = "select * from GANADERO.SAFIFUND S inner join GANADERO.SAFIFUNDREQUIREMENT SR on S.id = SR.\"idFund\" where S.id = @safiFoundId";
            //var sql = "select v.* from ganadero.vw_GetSafiFundWithRequirementAssociate v where v.\"safiFundId\" = @safiFoundId fetch first row only";
            var parameters = new { safiFoundId = safiFundId };
            var safiFundDictionary = new Dictionary<int, SafiFund>();

            var safiFoundCollection = (await DbConnection.QueryAsync<SafiFund, SafiFundRequirement, SafiFund>(sql,
                (safiFund, safiFundRequirement) =>
                {

                    SafiFund safiFundEntry;

                    if (!safiFundDictionary.TryGetValue(safiFund.id, out safiFundEntry))
                    {
                        safiFundEntry = safiFund;
                        safiFundEntry.safiFundRequirements = new List<SafiFundRequirement>();
                        safiFundDictionary.Add(safiFundEntry.id, safiFundEntry);
                    }

                    safiFundEntry.safiFundRequirements.Add(safiFundRequirement);
                    return safiFundEntry;
                }
                , param: parameters))
                //, splitOn: "Id"))
                .Distinct()
                .ToList();

            return safiFoundCollection.FirstOrDefault();
        }

        public Task<GetSafiFundRequirementDto> FindFirstOrDefault(Expression<Func<GetSafiFundRequirementDto, bool>> filter = null)
        {
            return null;
        }
    }
}

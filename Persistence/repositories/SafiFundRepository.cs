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
    public class SafiFundRepository : Repository<SafiFund>, ISafiFundRepository
    {
        public SafiFundRepository(DatabaseSettings dbSettings) : base(dbSettings)
        {
        }

        public async Task<IQueryable<GetSafiFundDto>> FindAllByFilter(
            Dictionary<string, int> additionalProps,
            Expression<Func<GetSafiFundDto, bool>> filter = null,
            Func<IQueryable<GetSafiFundDto>, IOrderedQueryable<GetSafiFundDto>> orderBy = null,
            RequestParameter pagination = null)
        {

            var sql = @"select v.* 
                        from ganadero.vw_GetSafiFundWithRequirementAssociate v ";
            //var parameters = new { codPersonTypeId =1 };
            var safiFoundCollection = (await DbConnection.QueryAsync<GetSafiFundDto>(sql, null))
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

        public async Task<SafiFund> FindBySafiFundId(int safiFundId, string personTypeCode = "")
        {


            var sql = "select * from GANADERO.SAFIFUND S inner join GANADERO.SAFIFUNDPERSONTYPE S2 on S2.\"idFund\" = s.id inner join GANADERO.CLASSIFIER P on S2.\"idClsPersonType\" = P.id inner join GANADERO.SAFIFUNDPERSONTYPEREQUIREMENT S3 on S3.\"idFundPersonType\" = s2.id inner join GANADERO.CLASSIFIER C on S3.\"idClsRequirement\" = C.id where S.id = @safiFoundId and P.abbreviation LIKE CONCAT('%',@personTypeCode,'%')";
            //var sql = "select * from GANADERO.SAFIFUND S inner join GANADERO.SAFIFUNDPERSONTYPE S2 on S2.\"idFund\" = s.id inner join GANADERO.SAFIFUNDPERSONTYPEREQUIREMENT S3 on S3.\"idFundPersonType\" = s2.id inner join GANADERO.CLASSIFIER C on S3.\"idClsRequirement\" = C.id where S.id = @safiFoundId";
            //var sql = "select * from GANADERO.SAFIFUND S inner join GANADERO.SAFIFUNDREQUIREMENT SR on S.id = SR.\"idFund\" where S.id = @safiFoundId";
            //var sql = "select v.* from ganadero.vw_GetSafiFundWithRequirementAssociate v where v.\"safiFundId\" = @safiFoundId fetch first row only";
            var parameters = new { safiFoundId = safiFundId, personTypeCode = personTypeCode };

            var safiFundDictionary = new Dictionary<int, SafiFund>();
            //var safiFundPersonTypeDictionary = new Dictionary<int, SafiFundPersonType>();

            
            var safiFoundCollection = (await DbConnection.QueryAsync<SafiFund, SafiFundPersonType, Classifier, SafiFundPersonTypeRequirement, Classifier, SafiFund>(sql,
                (safiFund, safiFundPersonTypes, clsPersonType, safiFundPersonTypeRequirements, clsRequirement) =>
                {

                    SafiFund safiFundEntry;

                    if (!safiFundDictionary.TryGetValue(safiFund.id, out safiFundEntry))
                    {
                        safiFundEntry = safiFund;
                        safiFundEntry.safiFundPersonTypes = new List<SafiFundPersonType>();
                        safiFundPersonTypes.safiFundPersonTypeRequirements = new List<SafiFundPersonTypeRequirement>();
                        safiFundPersonTypes.clsRequirements = new List<Classifier>();

                        //safiFundEntry.safiFundRequirements = new List<SafiFundPersonTypeRequirement>();

                        safiFundDictionary.Add(safiFundEntry.id, safiFundEntry);
                    }

                    int index = safiFundEntry.safiFundPersonTypes.FindIndex(x => x.clsPersonType.id == clsPersonType.id);
                    if (index >= 0)
                    {
                        safiFundEntry.safiFundPersonTypes[index].clsRequirements.Add(clsRequirement);
                        safiFundEntry.safiFundPersonTypes[index].clsPersonType = clsPersonType;

                    } else
                    {
                        safiFundPersonTypes.clsRequirements.Add(clsRequirement);
                        safiFundPersonTypes.clsPersonType = clsPersonType;
                        safiFundEntry.safiFundPersonTypes.Add(safiFundPersonTypes);
                    }
                    //safiFundEntry.safiFundPersonTypes
                    //safiFundPersonTypeRequirements.clsRequirement = clsRequirement;
                    //safiFundPersonTypeRequirements.clsRequirement

                    //safiFundPersonTypes.safiFundPersonTypeRequirements.Add(safiFundPersonTypeRequirements);
                    

                    //safiFundEntry.safiFundPersonTypes.Add(safiFundPersonTypes);

                    //safiFundEntry.safiFundRequirements.Add(safiFundPersonTypeRequirement);
                    return safiFundEntry;
                }
                , param: parameters))
                //, splitOn: "Id"))
                .Distinct()
                .ToList();

            return safiFoundCollection.FirstOrDefault();
        }
        
    }
}

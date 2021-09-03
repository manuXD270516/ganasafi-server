using Application.dtos;
using Application.helpers;
using Application.parameters;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Linq.Expressions;
using System.Text;
using System.Threading.Tasks;

namespace Application.interfaces
{
    public interface ISafiFundRequirementRepository : IRepository<SafiFundRequirement>
    {

        Task<IQueryable<GetSafiFundRequirementDto>> FindAllRequirementCustom(
            Dictionary<string,int> additionalProps,
            Expression<Func<GetSafiFundRequirementDto, bool>> filter = null,
            Func<IQueryable<GetSafiFundRequirementDto>, IOrderedQueryable<GetSafiFundRequirementDto>> orderBy = null,
            RequestParameter pagination = null
        );

        Task<GetSafiFundRequirementDto> FindFirstOrDefault(Expression<Func<GetSafiFundRequirementDto, bool>> filter = null);

        Task<GetSafiFundRequirementDto> FindBySafiFundId(int safiFundId);
    }
}

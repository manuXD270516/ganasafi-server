using Application.dtos;
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
    public interface ISafiFundRepository : IRepository<SafiFund>
    {

        Task<IQueryable<GetSafiFundDto>> FindAllByFilter(
          Dictionary<string, int> additionalProps,
          Expression<Func<GetSafiFundDto, bool>> filter = null,
          Func<IQueryable<GetSafiFundDto>, IOrderedQueryable<GetSafiFundDto>> orderBy = null,
          RequestParameter pagination = null
      );

        //Task<GetSafiFundDto> FindFirstOrDefault(Expression<Func<GetSafiFundDto, bool>> filter = null);

        Task<SafiFund> FindBySafiFundId(int safiFundId, string codPersonType);
    }
}

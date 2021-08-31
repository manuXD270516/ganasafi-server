using Ardalis.Specification;
using Domain.entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace Application.specifications
{
    public class PagedSafiDataTransfersSpecification : Specification<SafiDataTransfer>
    {

        public PagedSafiDataTransfersSpecification(int pageNumber, int pageSize, double accountNumber)
        {
            Query.Skip((pageNumber - 1) * pageSize)
                .Take(pageSize);

            if (double.IsNaN(accountNumber) || accountNumber == 0)
            {
                Query.Search(sdt => sdt.accountNumber.ToString(), $"%{accountNumber}%");
            }


        }
    }
}

using System;
using System.Collections.Generic;
using System.Text;

namespace Application.wrappers
{
    public class PageResponse<T>:  Response<T> 
    {

        public int pageNumber { get; set; }
        public int pageSize { get; set; }

        public PageResponse(T data, int pageNumber, int pageSize)
        {
            this.pageNumber = pageNumber;
            this.pageSize = pageSize;
            this.data = data;
            this.message = null;
            this.successed = true;
            this.errors = null;
        }


    }
}

using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Application.interfaces
{
    public interface IDbStrategy
    {
        IDbConnection GetConnection(string connectionString);
    }
}

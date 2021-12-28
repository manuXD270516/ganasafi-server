using Application.interfaces;
using System;
using System.Collections.Generic;
using System.Data;
using System.Text;

namespace Persistence.options
{
    public class DbContext
    {
        private IDbStrategy _dbStrategy;

        public DbContext SetStrategy(string providerType)
        {

            /**"SqlServer" => _dbStrategy = new SqlServerStrategy(),
                "MySql" => _dbStrategy = new MySqlStrategy(),*/
            _dbStrategy = providerType switch
            {
                "Postgresql" => _dbStrategy = new PostgreSqlStrategy(),
                //"MySQL" => _dbStrategy = new MySQLStrategy(),
                _ => null
            };

            return this;
        }

        public IDbConnection GetDbContext(string connectionString)
        {
            return _dbStrategy.GetConnection(connectionString);
        }
    }
}

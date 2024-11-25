using Microsoft.Data.SqlClient;
using Microsoft.Extensions.Configuration;
using My.Custom.Template.Infraestructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.Infraestructure
{
    public class ConnectionFactory : IConnectionFactory
    {
        private readonly IConfiguration _configuration;

        public ConnectionFactory(IConfiguration configuration)
        {
            _configuration = configuration;
        }

        public SqlConnection GetReadWriteConnection(ConnectionDB db) => new SqlConnection(getConnectionString(db));

        private string getConnectionString(ConnectionDB db)
        {

            string connectiondb;
            switch (db)
            {

                case ConnectionDB.DB_RW:
                    connectiondb = _configuration["DB_ReadWrite"];
                    break;

                case ConnectionDB.DB_RO:
                    connectiondb = _configuration["DB_ReadOnly"];
                    break;

                default:
                    connectiondb = "";
                    break;

            }
            return connectiondb;
        }
    }
}

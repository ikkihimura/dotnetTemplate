using Microsoft.Data.SqlClient;
using My.Custom.Template.Infraestructure.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.Infraestructure
{
    public interface IConnectionFactory
    {
        SqlConnection GetReadWriteConnection(ConnectionDB db);
    }
}

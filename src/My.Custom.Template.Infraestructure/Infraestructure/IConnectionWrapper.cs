using My.Custom.Template.Infraestructure.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.Infraestructure
{
    public interface IConnectionWrapper
    {
        Task ExecuteAsync(string procedureName, object parameters, ConnectionDB db);

        Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters, ConnectionDB db);

        Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, object parameters, ConnectionDB db, CommandType commandType = CommandType.StoredProcedure);

        Task OpenAndBeginTransactionAsync(ConnectionDB db, IsolationLevel isolationLevel = IsolationLevel.ReadUncommitted);

        Task ExecuteWithTransactionAsync(string procedureName, object parameters);

        Task ExecuteTransactionAsync(Func<Task> command, ConnectionDB db);

        Task<IEnumerable<T>> QueryWithTransactionAsync<T>(string procedureName, object parameters);

        void CommitAndClose();

        void RollbackAndClose();
    }
}

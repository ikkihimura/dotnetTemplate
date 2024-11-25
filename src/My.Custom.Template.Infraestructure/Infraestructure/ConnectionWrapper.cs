using Dapper;
using My.Custom.Template.Infraestructure.Enums;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.Infraestructure
{
    public class ConnectionWrapper : IConnectionWrapper, IDisposable
    {
        private readonly IConnectionFactory _connectionFactory;
        private IDbConnection _connectionForTransaction;
        private IDbTransaction _transaction;

        public ConnectionWrapper(IConnectionFactory connectionFactory)
        {
            _connectionFactory = connectionFactory;

        }

        public void CommitAndClose()
        {
            _transaction.Commit();
            _connectionForTransaction.Dispose();
            _transaction.Dispose();
            _connectionForTransaction = null;
        }

        public void Dispose()
        {
            _transaction?.Dispose();
            _connectionForTransaction?.Dispose();
        }

        public async Task ExecuteAsync(string procedureName, object parameters, ConnectionDB db)
        {
            using (var connection = _connectionFactory.GetReadWriteConnection(db))
            {
                connection.Open();

                await connection.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<IEnumerable<T>> QueryAsync<T>(string procedureName, object parameters, ConnectionDB db)
        {
            using (var connection = _connectionFactory.GetReadWriteConnection(db))
            {
                connection.Open();

                return await connection.QueryAsync<T>(procedureName, parameters,
                    commandType: CommandType.StoredProcedure);
            }
        }

        public async Task<T> QueryFirstOrDefaultAsync<T>(string procedureName, object parameters, ConnectionDB db, CommandType commandType = CommandType.StoredProcedure)
        {
            using (var connection = _connectionFactory.GetReadWriteConnection(db))
            {
                connection.Open();

                return await connection.QueryFirstOrDefaultAsync<T>(procedureName, parameters,
                    commandType: commandType);
            }
        }


        public async Task OpenAndBeginTransactionAsync(ConnectionDB db, IsolationLevel isolationLevel)
        {
            if (_connectionForTransaction == null)
            {
                _connectionForTransaction = _connectionFactory.GetReadWriteConnection(db);
                _connectionForTransaction.Open();
            }

            _transaction = _connectionForTransaction.BeginTransaction(isolationLevel);
        }

        public async Task ExecuteWithTransactionAsync(string procedureName, object parameters)
        {
            await _connectionForTransaction.ExecuteAsync(procedureName, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public async Task ExecuteTransactionAsync(Func<Task> command, ConnectionDB db)
        {
            try
            {
                await OpenAndBeginTransactionAsync(db, IsolationLevel.Serializable);

                await command();

                CommitAndClose();
            }
            catch (Exception ex)
            {

                RollbackAndClose();
                throw ex;

            }
        }


        public async Task<IEnumerable<T>> QueryWithTransactionAsync<T>(string procedureName, object parameters)
        {
            return await _connectionForTransaction.QueryAsync<T>(procedureName, parameters, commandType: CommandType.StoredProcedure, transaction: _transaction);
        }

        public void RollbackAndClose()
        {
            _transaction.Rollback();
            _connectionForTransaction.Dispose();
            _transaction.Dispose();
            _connectionForTransaction = null;
        }
    }
}

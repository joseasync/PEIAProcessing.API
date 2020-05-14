using System;
using System.Data;
using System.Data.SqlClient;

namespace PEIAProcessing.Data
{
    public class BaseConnection
    {
        private readonly Domain.Entities.ConnectionConfig _dbConnectionConfig;

        protected BaseConnection(Domain.Entities.ConnectionConfig connectionConfig) => _dbConnectionConfig = connectionConfig;

        public IDbConnection OpenConnection()
        {
            try
            {
                var dbConnection = new SqlConnection(_dbConnectionConfig.DbPeiaProcessingConnection);
                dbConnection.Open();
                return dbConnection;
            }
            catch (Exception e)
            {
                throw e;
            }

        }

    }
}

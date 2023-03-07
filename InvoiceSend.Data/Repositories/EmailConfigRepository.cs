using InvoiceSend.Model;
using Oracle.ManagedDataAccess.Client;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSend.Data.Repositories
{
    public class EmailConfigRepository : IEmailConfigRepository
    {
        private OracleSQLConfiguration _connectionString;

        public EmailConfigRepository(OracleSQLConfiguration connectionString) => _connectionString = connectionString;

        protected OracleConnection dbConnection()
        {
            return new OracleConnection(_connectionString.ConnectionString);
        }

        public EmailConfig GetConfiguration()
        {
            EmailConfig emailConfig = new EmailConfig();

            var db = dbConnection();

            var sql = @"SELECT * FROM CONFIG"; 

            var cmd = db.CreateCommand();
            cmd.CommandText = sql;

            OracleDataReader reader = cmd.ExecuteReader();

            while (reader.Read())
            {
                emailConfig.User = reader.GetString(1);
            }

            return emailConfig;
        }
    }
}

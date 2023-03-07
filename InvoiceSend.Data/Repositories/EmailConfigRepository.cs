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
                emailConfig.Id = reader.GetInt32(0);
                emailConfig.User= reader.GetString(1);
                emailConfig.Email= reader.GetString(2);
                emailConfig.BccEmail = reader.GetString(3);
                emailConfig.Driver = reader.GetString(4);
                emailConfig.Host = reader.GetString(5);
                emailConfig.Port= reader.GetInt32(6);
                emailConfig.UserName = reader.GetString(7);
                emailConfig.Password = reader.GetString(8);
                emailConfig.Encryption = reader.GetString(9);
                emailConfig.FromAddress = reader.GetString(10);
                emailConfig.FromName = reader.GetString(11);
                emailConfig.Excution = reader.GetInt32(12);
                emailConfig.Second = reader.GetInt32(13);
            }

            return emailConfig;
        }
    }
}

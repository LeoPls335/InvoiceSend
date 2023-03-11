using InvoiceSend.Model;
using Oracle.ManagedDataAccess.Client;

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

            var sql = @"SELECT ID, USUARIO, CORREO_PRINCIPAL, CORREO_COPIA_OCULTA,
                               MAIL_DRIVER, MAIL_HOST, MAIL_PORT, MAIL_USERNAME,
                               MAIL_PASSWORD, MAIL_ENCRYPTION, MAIL_FROM_ADDRESS,
                               MAIL_FROM_NAME, MAILS_PER_EXECUTION, MAILS_PER_SECOND
                               FROM NOTIFICACION_CORREO"; 

            var cmd = db.CreateCommand();
            cmd.CommandText = sql;
            db.Open();

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
                emailConfig.Excution = reader.GetString(12);
                emailConfig.Second = reader.GetString(13);
            }

            return emailConfig;
        }
    }
}

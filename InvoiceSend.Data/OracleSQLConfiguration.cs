using System;
using System.Collections.Generic;
using System.Security.Cryptography.X509Certificates;
using System.Text;

namespace InvoiceSend.Data
{
    public class OracleSQLConfiguration
    {
        public OracleSQLConfiguration(string connectionString) => ConnectionString= connectionString;

        public string ConnectionString { get; set; }
    }
}

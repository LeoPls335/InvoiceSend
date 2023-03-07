using System;
using System.Collections.Generic;
using System.Text;

namespace InvoiceSend.Model
{
    public class EmailConfig
    {
        public int Id { get; set; }
        public string User { get; set; }
        public string Email { get; set; }
        public string BccEmail { get; set; }
        public string Driver { get; set;}
        public string Host { get; set; }
        public int Port { get; set; }
        public string UserName { get; set; }
        public string Password { get; set; }
        public string Encryption { get; set; }
        public string FromAddress { get; set; }
        public string FromName { get; set; }
        public int Excution { get; set; }
        public int Second { get; set; }
    }
}

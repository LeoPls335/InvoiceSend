using InvoiceSend.Model;
using System;
using System.Collections;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace InvoiceSend.Data.Repositories
{
    public interface IEmailConfigRepository
    {
        EmailConfig GetConfiguration();
    }
}

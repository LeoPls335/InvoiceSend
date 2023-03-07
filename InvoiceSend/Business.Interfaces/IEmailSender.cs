using System;
using System.Collections.Generic;
using System.Net.Mail;
using System.Threading.Tasks;
using InvoiceSend.Entities;

namespace InvoiceSend.Business.Interfaces
{
	public interface IEmailSender
	{
        Task SendEmailAsync(EmailSend emailSend);
        Task SendEmailWithAttachmentsAsync(EmailSendAttachments emailSend);
    }
}


using System;
using System.Collections.Generic;
using System.Net;
using System.Net.Mail;
using System.Threading.Tasks;
using InvoiceSend.Business.Interfaces;
using InvoiceSend.Data.Repositories;
using InvoiceSend.Entities;
using InvoiceSend.Model;
using Microsoft.Extensions.Options;

namespace InvoiceSend.Business
{
    public class EmailSender : IEmailSender
    {
        private readonly IEmailConfigRepository _emailConfigRepository;

        public EmailSender(IEmailConfigRepository emailConfigRepository)
        {
            _emailConfigRepository = emailConfigRepository;
        }

        public Task SendEmailAsync(EmailSend emailSend)
        {
            Execute(emailSend, null).Wait();

            return Task.FromResult(0);
        }

        public Task SendEmailWithAttachmentsAsync(EmailSendAttachments emailSend)
        {
            Execute(emailSend.emailSend, emailSend.list).Wait();

            return Task.FromResult(0);
        }

        public async Task Execute(EmailSend emailSend, List<Attachment> attachments)
        {
            try
            {
                EmailConfig emailConfig = _emailConfigRepository.GetConfiguration();

                var toEmail = string.IsNullOrEmpty(emailSend.Email) ? emailConfig.Email : emailSend.Email;

                MailMessage mail = new MailMessage()
                {
                    From = new MailAddress(emailConfig.FromAddress, emailConfig.FromName)
                };

                mail.To.Add(new MailAddress(toEmail));

                if (!string.IsNullOrEmpty(emailConfig.BccEmail))
                    mail.Bcc.Add(new MailAddress(emailConfig.BccEmail));

                if (attachments != null)
                {
                    foreach (var item in attachments)
                    {
                        mail.Attachments.Add(item);
                    }
                }

                mail.Subject = emailSend.Subject;
                mail.Body = emailSend.Message;
                mail.IsBodyHtml = true;
                mail.Priority = MailPriority.Normal;

                bool ssl = emailConfig.Encryption.Contains("tls") ? true : false;

                using (SmtpClient smtp = new SmtpClient(emailConfig.Host, emailConfig.Port))
                {
                    smtp.UseDefaultCredentials = false;
                    smtp.Credentials = new NetworkCredential(emailConfig.UserName, emailConfig.Password);
                    smtp.EnableSsl = ssl;

                    await smtp.SendMailAsync(mail);
                }
            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
    }
}


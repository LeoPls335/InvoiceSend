using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using InvoiceSend.Business.Interfaces;
using InvoiceSend.Entities;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace InvoiceSend.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Produces("application/json")]
    public class EmailController : ControllerBase
    {
        private readonly IEmailSender _emailSender;

        public EmailController(IEmailSender emailSender)
        {
            _emailSender = emailSender;
        }

        /// <summary>
        /// SendEmail.
        /// </summary>
        /// <param name="emailSend"></param>
        [HttpPost]
        [Route("SendEmail")]
        public async Task SendEmail(EmailSend emailSend)
        {
            await _emailSender.SendEmailAsync(emailSend);
        }

        /// <summary>
        /// SendEmailWithAttachments.
        /// </summary>
        /// <param name="emailSend"></param>
        [HttpPost]
        [Route("SendEmailWithAttachments")]
        public async Task SendEmailWithAttachments(EmailSendAttachments emailSend)
        {
            await _emailSender.SendEmailWithAttachmentsAsync(emailSend);
        }
    }
}


using System;
using System.Collections.Generic;
using System.Net.Mail;

namespace InvoiceSend.Entities
{
	public class EmailSendAttachments
	{
		public EmailSend emailSend { get; set; }
		public List<Attachment> list { get; set; }
    }
}


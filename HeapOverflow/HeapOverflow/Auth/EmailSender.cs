using HeapOverflow.Config;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Mail;
using System.Web;

namespace HeapOverflow.Auth
{
    public class EmailSender
    {
        private static readonly Logger _log = new Logger("EmailSender");

        private readonly string username = "gudratlicompany@gmail.com";
        private readonly string password = "ziqqeshzomumybpl";
        private readonly string sender = "Heap Overflow";
        private readonly string subject = "Email confirmation";
		private readonly string body;

        private string email;
        private string code;

        private DateTime sendTime;

        public string Email { set => email = value; }
        public string Code { get => code; }
        public DateTime SendTime { get => sendTime; }

        public EmailSender ()
        {
            code = new Random().Next(100000, 999999).ToString();
			body = "Code: <b>" + code + "</b>";
		}

        public void SendEmail()
        {
            SmtpClient smtp;
            using (smtp = new SmtpClient())
            {
                FillSMTP(smtp);

                try
                {
                    smtp.Send(GetMailMessage());
                    sendTime = DateTime.Now;
                }
                catch (Exception ex)
                {
                    _log.Log(ex.Message + "\r\n" + ex.StackTrace);
                }
            };
        }

		private MailMessage GetMailMessage()
		{
			MailMessage message = new MailMessage();
			message.To.Add(new MailAddress(email));
			message.From = new MailAddress(username, sender);
			message.Subject = subject;
			message.IsBodyHtml = true;
			message.Body = body;

			return message;
		}

		private void FillSMTP (SmtpClient smtp)
        {
            smtp.DeliveryMethod = SmtpDeliveryMethod.Network;
            smtp.UseDefaultCredentials = false;
            smtp.EnableSsl = true;
            smtp.Host = "smtp.gmail.com";
            smtp.Port = 587;
            smtp.Credentials = new NetworkCredential(username, password);
        }
    }
}
using MailKit.Net.Smtp;
using MailKit.Security;
using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading.Tasks;

namespace Mailservice
{
    public interface IEmailSender1
    {
        void SendEmail(Message message);
    }
    public class EmailSender: IEmailSender1
    {
        private EmailConfiguration _EmailConfig { get; }

        public EmailSender(EmailConfiguration emailConfig)
        {
            _EmailConfig = emailConfig;
        }

        public void SendEmail(Message message)
        {
            var emailMessage = CreateEmailMessage(message);

            Send(emailMessage);

        }

        private MimeMessage CreateEmailMessage(Message message)
        {
            var emailMessage = new MimeMessage();
            emailMessage.From.Add( MailboxAddress.Parse(  _EmailConfig.From));
            emailMessage.To.AddRange(message.To);
            emailMessage.Subject = message.Subject;
            var bulder = new BodyBuilder();
            bulder.HtmlBody = message.Content;
            byte[] filebytes;
            if (System.IO.File.Exists(message.Attachment))
            {
                FileStream file = new FileStream(message.Attachment,FileMode.Open,FileAccess.Read);
                using (var ms=new MemoryStream())
                {
                    file.CopyTo(ms);
                    filebytes = ms.ToArray();
                }
                bulder.Attachments.Add(message.Attachment,filebytes,ContentType.Parse("application/vnd.openxmlformats-officedocument.spreadsheetml.sheet"));
            }
            emailMessage.Body = bulder.ToMessageBody();
            return emailMessage;
        }
        private void Send(MimeMessage message)
        {
            using (var client =new MailKit.Net.Smtp.SmtpClient())
            {
                try
                {
                    client.Connect(_EmailConfig.SmtpServer, _EmailConfig.Port ,SecureSocketOptions.StartTls);
                    client.AuthenticationMechanisms.Remove("XOAUTH2");
                    client.Authenticate(_EmailConfig.From,_EmailConfig.Password);
                    client.Send(message);
                }
                catch (Exception)
                {

                    throw;
                }
                finally 
                {
                    client.Disconnect(true);
                    client.Dispose(); 
                }
            }
        }

    }
}

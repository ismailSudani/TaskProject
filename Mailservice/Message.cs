using MimeKit;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Mailservice
{
    public class Message
    {
        public List<MailboxAddress> To { get; set; }
        public string Subject { get; set; }
        public string Content { get; set; }
        public string Attachment { get; set; }
        public Message(IEnumerable<string> to, string subject, string content, string Attach)
        {
            To = new List<MailboxAddress>();

            To.Add(MailboxAddress.Parse(to.First()));
            Subject = subject;
            Content = content;
            Attachment = Attach;
        }
      
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services.ViewModels
{
    public class NotificationContent
    {
        public NotificationContent() { }
        public NotificationContent(string subject, string body, params string[] sendTo)
        {
            this.Subject = subject;
            this.Body = body;
            this.SendTo = sendTo;
        }
        public string Subject { get; set; }
        public string Body { get; set; }
        public string[] SendTo { get; set; }
    }
}

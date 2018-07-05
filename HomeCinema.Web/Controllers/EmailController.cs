using HomeCinema.Services;
using HomeCinema.Services.Abstract;
using HomeCinema.Services.ViewModels;
using HomeCinema.Web.Models;
using System.Web.Http;

namespace HomeCinema.Web.Controllers
{
    [RoutePrefix("api/email")]
    public class EmailController : ApiController
    {
        [HttpPost]
        [Route("send")]
        public IHttpActionResult SendMessageToPrivate(EmailViewModel email)
        {
                IMailService mailService = new MailService();
                var rs = new NotificationContent
                {
                    Subject = "Visitor from duynamtin",
                    Body = string.Format("Body: {0}<br/> Name: {1}<br/> Phone: {2} <br/> Email: {3}", email.Body, email.Name, email.Phone, email.EmailFrom),
                    SendTo = new[] { "duynamtin@gmail.com" }
                };
                mailService.SendMailAsync(rs);
            return Ok();
        }
    }
}

using HomeCinema.Services.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace HomeCinema.Services.Abstract
{
    public interface IMailService
    {
        Task SendMailAsync(NotificationContent email);
    }
}

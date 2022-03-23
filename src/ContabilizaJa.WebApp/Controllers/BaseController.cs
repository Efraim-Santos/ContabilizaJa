using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.WebApp.Controllers
{
    public class BaseController : Controller
    {
        private readonly IHostingEnvironment _appEnvironment;
        private readonly DomainNotificationHandler _notifications;
        protected Guid ClienteId = Guid.Parse("4885e451-b0e4-4490-b959-04fabc806d32");

        public BaseController(IHostingEnvironment env,
                              INotificationHandler<DomainNotification> notifications)
        {
            _appEnvironment = env;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public IEnumerable<string> ObterMensagens()
        {
            return _notifications.ObterNotificacoes().Select(c => c.Mensagem).ToList();
        }

        public string GetPathRootFiles()
        {
            return _appEnvironment.WebRootPath;
        }
    }
}
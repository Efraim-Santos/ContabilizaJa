using ContabilizaJa.Processamento.ApplicationCore.Commands;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using MediatR;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.WebApp.Controllers
{
    
    public class ProcessarArquivoController : Controller
    {
        private readonly IMediator _mediator;
        private readonly DomainNotificationHandler _notifications;

        public ProcessarArquivoController(IMediator mediator, INotificationHandler<DomainNotification> notifications)
        {
            _mediator = mediator;
            _notifications = (DomainNotificationHandler)notifications;
        }

        public IActionResult Index()
        {
            return View();
        }
            
        [HttpPost]
        public async Task<IActionResult> Post([FromBody]AdicionarExtratoBancarioCommand exemplo)
        {   
            var teste = await _mediator.Send(exemplo);
            var teste2 = _notifications.ObterNotificacoes().Select(c => c.Mensagem).ToList();
            return Ok(teste);
        }
    }
}

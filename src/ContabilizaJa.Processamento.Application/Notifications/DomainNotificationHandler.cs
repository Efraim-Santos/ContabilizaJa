using MediatR;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace ContabilizaJa.Processamento.ApplicationCore.Notifications
{
    public class DomainNotificationHandler : INotificationHandler<DomainNotification>
    {
        private readonly List<DomainNotification> _notificacoes;

        public DomainNotificationHandler()
        {
            _notificacoes = new List<DomainNotification>();
        }

        public Task Handle(DomainNotification notificacao, CancellationToken cancellationToken)
        {
            _notificacoes.Add(notificacao);

            return Task.CompletedTask;
        }

        public virtual List<DomainNotification> ObterNotificacoes()
        {
            return _notificacoes;
        }
        //public void Dispose()
        //{
        //    _notificacoes = new List<DomainNotification>();
        //}
    }
}

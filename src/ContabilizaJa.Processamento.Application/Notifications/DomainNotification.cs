using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Processamento.ApplicationCore.Notifications
{
    public class DomainNotification : INotification
    {
        public string Commamd { get; private set; }
        public string Mensagem { get; private set; }
        public DateTime Timestamp { get; private set; }

        public DomainNotification(string commamd, string mensagem)
        {
            Commamd = commamd;
            Mensagem = mensagem;
            Timestamp = DateTime.Now;
        }
    }
}

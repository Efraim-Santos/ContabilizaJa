using MediatR;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Processamento.ApplicationCore.Commands
{
    public class RemoverExtratoBancarioCommand :  IRequest<bool>
    {
        public int Id { get; set; }
    }
}

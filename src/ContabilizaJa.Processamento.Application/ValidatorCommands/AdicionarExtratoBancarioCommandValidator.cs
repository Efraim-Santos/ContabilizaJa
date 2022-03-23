using ContabilizaJa.Processamento.ApplicationCore.Commands;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Processamento.ApplicationCore.ValidatorCommands
{
    public class AdicionarExtratoBancarioCommandValidator : AbstractValidator<AdicionarExtratoBancarioCommand>
    {
        public AdicionarExtratoBancarioCommandValidator()
        {
            RuleFor(e => e.ExtratoBancario)
               .NotNull().WithMessage("Nenhum extrato foi passado.");
        }
    }
}

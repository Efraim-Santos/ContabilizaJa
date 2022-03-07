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
            RuleFor(e => e.DataInicio)
                   .NotEmpty().WithMessage("A Data de inicio é inválida.")
                   .NotNull().WithMessage("A Data de inicio é inválida.");

            RuleFor(e => e.DataFim)
                .NotEmpty().WithMessage("A Data de fim é inválida.")
                .NotNull().WithMessage("A Data de fim é inválida.");

            RuleFor(e => e.Transacoes)
               .NotNull().WithMessage("A Data de inicio é inválida.");
        }
    }
}

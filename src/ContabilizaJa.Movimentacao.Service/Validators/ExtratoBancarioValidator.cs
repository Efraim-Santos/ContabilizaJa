using ContabilizaJa.Movimentacao.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Service.Validators
{
    public class ExtratoBancarioValidator : AbstractValidator<ExtratoBancario>
    {
        public ExtratoBancarioValidator()
        {
            RuleFor(e => e.DataInicio)
                .NotEmpty().WithMessage("A Data de inicio é inválida.")
                .NotNull().WithMessage("A Data de inicio é inválida.");

            RuleFor(e => e.DataFim)
                .NotEmpty().WithMessage("A Data de fim é inválida.")
                .NotNull().WithMessage("A Data de fim é inválida.");

            RuleFor(e => e.DataRegistro)
                .NotEmpty().WithMessage("A Data do registro é inválida.")
                .NotNull().WithMessage("A Data do registro é inválida.");

            RuleFor(e => e.Transacoes)
               .NotNull().WithMessage("A Data de inicio é inválida.");
        }
    }
}

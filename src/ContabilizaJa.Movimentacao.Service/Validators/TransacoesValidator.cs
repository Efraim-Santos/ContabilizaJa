using ContabilizaJa.Movimentacao.Domain;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Service.Validators
{
    public class TransacoesValidator : AbstractValidator<Transacoes>
    {
        public TransacoesValidator()
        {
            RuleFor(t => t.Tipo)
                .MaximumLength(50).WithMessage("O tipo da transacao é inválida, pois passou dos 50 caracteres.")
                .NotEmpty().WithMessage("O tipo da transacao é inválida.")
                .NotNull().WithMessage("O tipo da transacao é inválida.");

            RuleFor(t => t.Data)
                .NotEmpty().WithMessage("A data é inválida.")
                .NotNull().WithMessage("O data é inválida.");

            RuleFor(t => t.Valor)
                .GreaterThan(0).WithMessage("O valor precisa ser maior que 0");

            RuleFor(t => t.Descricao)
                .MaximumLength(250).WithMessage("A descrição é inválida, pois passou dos 250 caracteres.")
                .NotEmpty().WithMessage("A data é inválida.")
                .NotNull().WithMessage("O data é inválida.");

            RuleFor(t => t.Extrato)
                .NotEmpty().WithMessage("O extrato é inválido.")
                .NotNull().WithMessage("O extrato é inválido.");
        }
    }
}

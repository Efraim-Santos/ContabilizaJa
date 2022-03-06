using ContabilizaJa.Movimentacao.Domain.Core;
using FluentValidation;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Service.Services
{
    public class BaseEntityServices
    {
        protected bool Validador<TEntity>(AbstractValidator<TEntity> validacao, TEntity entidade) where TEntity : Entity
        {
            var validator = validacao.Validate(entidade);

            if (validator.IsValid) return true;

            validacao.ValidateAndThrow(entidade);

            return false;
        }

        //protected bool ExecutarValidacao<TV, TE>(TV validacao, TE entidade) where TV : AbstractValidator<TE> where TE : Entity
        //{
        //    var validator = validacao.Validate(entidade);

        //    if (validator.IsValid) return true;

        //    Notificar(validator);

        //    return false;
        //}


        //private void Validate(TEntity obj, AbstractValidator<TEntity> validator)
        //{
        //    if (obj == null)
        //        throw new Exception("Registros não detectados!");

        //    validator.ValidateAndThrow(obj);
        //}
    }
}


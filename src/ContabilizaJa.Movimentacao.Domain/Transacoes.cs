using ContabilizaJa.Movimentacao.Domain.Core;
using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Movimentacao.Domain
{
    public class Transacoes : Entity
    {
        public string Tipo { get; private set; }

        public DateTime Data { get; private set; }

        public decimal Valor { get; private set; }

        public string Descricao { get; private set; }

        public ExtratoBancario Extrato { get; private set; }

        public Transacoes(string tipo, DateTime data, decimal valor, string descricao)
        {
            Tipo = tipo;
            Data = data;
            Valor = valor;
            Descricao = descricao;
        }
    }
}

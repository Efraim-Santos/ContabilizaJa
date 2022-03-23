using ContabilizaJa.Movimentacao.Application;
using ContabilizaJa.Processamento.Domain;
using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;

namespace ContabilizaJa.Processamento.CrossCutting
{
    public static class ConverterTransacoesBancariaParaViewModel
    {
        public static ExtratoBancarioViewModels Converter(IEnumerable<TransacoesBancaria> transacoes)
        { 
            var extratoViewModel = new ExtratoBancarioViewModels();

            var selecionarDistintos = transacoes.Select(t => new { t.TRNTYPE, t.DTPOSTED, t.TRNAMT, t.MEMO }).Distinct();
            
            foreach (var transacao in selecionarDistintos)
            {
                extratoViewModel.Transacoes.Add(new TransacoesViewModel
                {
                    Tipo = transacao.TRNTYPE.Equals("DEBIT") ? "Débito" : "Crédito",
                    Data = DateTime.ParseExact(transacao.DTPOSTED.Split("[")[0], "yyyyMMddHHmmss", CultureInfo.InvariantCulture),
                    Valor = Convert.ToDecimal(transacao.TRNAMT.Replace("-", "").Replace(".", ",")),
                    Descricao = transacao.MEMO.Trim()
                });
            }

            return extratoViewModel;
        }
        public static ExtratoBancarioViewModels ConverterTipo(IEnumerable<TransacoesBancaria> transacoes)
        {
            var extratoViewModel = new ExtratoBancarioViewModels();

            foreach (var transacao in transacoes)
            {
                extratoViewModel.Transacoes.Add(new TransacoesViewModel
                {
                    Tipo = transacao.TRNTYPE,
                    Data = DateTime.Parse(transacao.DTPOSTED),
                    Valor = Convert.ToDecimal(transacao.TRNAMT),
                    Descricao = transacao.MEMO
                });
            }

            return extratoViewModel;
        }
    }
}
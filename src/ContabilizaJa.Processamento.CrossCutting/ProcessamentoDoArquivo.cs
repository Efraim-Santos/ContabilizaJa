using ContabilizaJa.Processamento.CrossCutting.Extensions;
using ContabilizaJa.Processamento.Domain;
using Microsoft.AspNetCore.Http;
using System;
using System.Collections.Generic;
using System.IO;
using System.Threading.Tasks;

namespace ContabilizaJa.Processamento.CrossCutting
{
    public static class ProcessamentoDoArquivo
    {
        private const string TransacaoTag = "STMTTRN";

        public static IEnumerable<TransacoesBancaria> LerArquivos(List<IFormFile> arquivos)
        {
            var extrato = new List<TransacoesBancaria>();

            foreach (var arquivo in arquivos)
            {
                if (arquivo.Length > 0)
                {
                    var stream = arquivo.OpenReadStream();

                    StreamReader sr = new StreamReader(stream);

                    string linha;

                    while ((linha = sr.ReadLine()) != null)
                    {
                        linha = linha.Trim();

                        if (linha.Contains($"<{TransacaoTag}>"))
                        {
                            var transacaoCorrente = new TransacoesBancaria();

                            while (!(linha = sr.ReadLine()).Contains($"</{TransacaoTag}>"))
                            {
                                var nomeDaTag = TratarLinhaExtension.BuscarNomeTag(linha);
                                var valorDaTag = TratarLinhaExtension.BuscarValorDaTag(nomeDaTag, linha);
                                transacaoCorrente = TratarLinhaExtension.AtribuirValor(transacaoCorrente, nomeDaTag, valorDaTag);
                            }

                            extrato.Add(transacaoCorrente);
                        }
                    }
                }
            }
            return extrato;
        }
    }
}




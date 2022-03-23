using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ContabilizaJa.Processamento.CrossCutting.Extensions
{
    public static class TratarLinhaExtension
    {
        public static string BuscarNomeTag(string linha)
        {
            try
            {
                return linha.Substring(1, linha.IndexOf(">") - 1);
            }
            catch (Exception)
            {
                return string.Empty;
            }
        }

        public static string BuscarValorDaTag(string nomeDaTag, string linha)
        {
            return linha.Replace($"<{nomeDaTag}>", string.Empty);
        }

        public static T AtribuirValor<T>(T objeto, string nomeDaTag, object valor)
        {
            var prop = objeto.GetType().GetProperties().Where(p => p.Name == nomeDaTag).FirstOrDefault();
            prop?.SetValue(objeto, valor);
            return objeto;
        }
    }
}

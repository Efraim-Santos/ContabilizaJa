using System;
using System.Collections.Generic;
using System.Text;

namespace ContabilizaJa.Processamento.Domain
{
    public class TransacoesBancaria
    {
        /// <summary>
        /// Tipo de transação: Débito ou crédito
        /// </summary>
        public string TRNTYPE { get; set; }
        /// <summary>
        /// Data da transação no formato YYYYMMDDHHMMSS
        /// </summary>
        public string DTPOSTED { get; set; }
        /// <summary>
        /// Valor (será negativo quando a transação for debito
        /// </summary>
        public string TRNAMT { get; set; }
        /// <summary>
        /// Descrição da transção
        /// </summary>
        public string MEMO { get; set; }
    }
}

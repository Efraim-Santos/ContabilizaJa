using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Text;

namespace ContabilizaJa.Movimentacao.Application
{
    public class TransacoesViewModel
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O {0} da transação é obrigatório.")]
        [StringLength(50, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres.")]
        public string Tipo { get; set; }

        [Required(ErrorMessage = "A {0} da transação é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de {0} inválida.")]
        public DateTime Data { get; set; }

        [Required(ErrorMessage = "O {0} da transação é obrigatório.")]
        public decimal Valor { get; set; }

        [StringLength(250, ErrorMessage = "O tamanho máximo do campo {0} é de {1} caracteres.")]
        public string Descricao { get; set; }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace ContabilizaJa.Movimentacao.Application
{
    public class ExtratoBancarioViewModels
    {
        [Key]
        public int Id { get; set; }

        [StringLength(250)]
        public string Periodo { get; set; }

        [Required(ErrorMessage = "A {0} é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de {0} inválida.")]
        public DateTime DataInicio { get; set; }

        [Required(ErrorMessage = "A {0 é obrigatório.")]
        [DataType(DataType.DateTime, ErrorMessage = "Formato de {0} inválida.")]
        public DateTime DataFim { get; set; }

        [ScaffoldColumn(false)]
        public DateTime DataRegistro { get; set; }

        public List<TransacoesViewModel> Transacoes { get; set; } = new List<TransacoesViewModel>();
    }
}

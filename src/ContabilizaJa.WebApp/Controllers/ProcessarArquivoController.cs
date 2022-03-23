using ContabilizaJa.Processamento.ApplicationCore.Commands;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using ContabilizaJa.Processamento.CrossCutting;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Threading.Tasks;
using usandoIO = System.IO;

namespace ContabilizaJa.WebApp.Controllers
{
    public class ProcessarArquivoController : BaseController
    {
        private readonly IMediator _mediator;

        public ProcessarArquivoController(IHostingEnvironment env,
                                          INotificationHandler<DomainNotification> notifications,
                                          IMediator mediator) : base(env, notifications)
        {
            _mediator = mediator;
        }

        public IActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public IActionResult CarregarArquivo(List<IFormFile> arquivos)
        {
            if (!arquivos.Any())
            {
                ViewData["Error"] = "Nenhum Arquivo foi selecionado";
                return View("Index");
            }

            var arquivoExtensao = arquivos.Any(a => !a.FileName.Contains(".ofx"));

            if (arquivoExtensao)
            {
                ViewData["Error"] = $"A Extensão do(s) arquivo é invalida, favor carregar somente arquivo do tipo ofx!";
                return View("Index");
            }

             var transacoes = ProcessamentoDoArquivo.LerArquivos(arquivos);

            var extratoBancario = ConverterTransacoesBancariaParaViewModel.Converter(transacoes);

            return View("CarregarTransacoesBancarias", extratoBancario);
        }
    }
}

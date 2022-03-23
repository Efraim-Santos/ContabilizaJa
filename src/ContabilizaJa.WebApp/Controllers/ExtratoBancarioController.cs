using ContabilizaJa.Movimentacao.Data.Queries;
using ContabilizaJa.Processamento.ApplicationCore.Commands;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using ContabilizaJa.Processamento.CrossCutting;
using ContabilizaJa.Processamento.Domain;
using MediatR;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.WebApp.Controllers
{
    public class ExtratoBancarioController : BaseController
    {
        private readonly IExtratoBancarioQueries _extratoBancarioQueries;
        private readonly IMediator _mediator;

        public ExtratoBancarioController(IHostingEnvironment env,
                                         INotificationHandler<DomainNotification> notifications,
                                         IExtratoBancarioQueries extratoBancarioQueries,
                                         IMediator mediator) : base(env, notifications)
        {
            _extratoBancarioQueries = extratoBancarioQueries;
            _mediator = mediator;
        }

        [HttpGet]
        public async Task<IActionResult> Index()
        {
            var todosExtratos = await _extratoBancarioQueries.ObterListaDeExtratos();

            return View("Index", todosExtratos);
        }

        [HttpGet("BuscarExtratos")]
        public async Task<IActionResult> Get()
        {
            var todosExtratos = await _extratoBancarioQueries.ObterListaDeExtratos();

            return View("Index", todosExtratos);
        }

        [HttpGet("ConsultarExtrato/{id:int}")]
        public async Task<IActionResult> Get(int id)
        {
            var extrato = await _extratoBancarioQueries.ConsultarExtrato(id);

            return View("Transacoes/TransacoesBancarias", extrato);
        }

        [HttpPost("CadastrarExtrato")]
        public async Task<IActionResult> Post([FromBody] IEnumerable<TransacoesBancaria> extrato)
        {
            var extratoTransacoes = new AdicionarExtratoBancarioCommand
            {
                ExtratoBancario = ConverterTransacoesBancariaParaViewModel.ConverterTipo(extrato)
            };

            var resultado = await _mediator.Send(extratoTransacoes);

            return Json(new { success = resultado, message = ObterMensagens().FirstOrDefault()});
        }

        [HttpDelete("Remover/{id:int}")]
        public async Task<IActionResult> Delete(int id)
        {
            var extratoId = new RemoverExtratoBancarioCommand { IdExtrato = id };

            var resultado = await _mediator.Send(extratoId);

            if (resultado)
                ViewData["Success"] = ObterMensagens();
            else
                ViewData["Error"] = ObterMensagens();

            return View("Index");
        }
    }
}

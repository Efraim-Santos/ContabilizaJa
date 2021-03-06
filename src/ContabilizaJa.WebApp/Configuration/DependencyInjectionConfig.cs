using ContabilizaJa.Movimentacao.Data;
using ContabilizaJa.Movimentacao.Data.Queries;
using ContabilizaJa.Movimentacao.Data.Repository;
using ContabilizaJa.Processamento.ApplicationCore.Commands;
using ContabilizaJa.Processamento.ApplicationCore.Notifications;
using MediatR;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.WebApp.Configuration
{
    public static class DependencyInjectionConfig
    {
        public static void ResolveDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IExtratoBancarioRepository, ExtratoBancarioRepository>();
            services.AddScoped<IUnitOfWork, UnitOfWork>();
            services.AddScoped<IRequestHandler<AdicionarExtratoBancarioCommand, bool>, ExtratoBancarioCommandHandler>();
            services.AddScoped<IRequestHandler<RemoverExtratoBancarioCommand, bool>, ExtratoBancarioCommandHandler>();
            services.AddScoped<INotificationHandler<DomainNotification>, DomainNotificationHandler>();
            services.AddScoped<IExtratoBancarioQueries, ExtratoBancarioQueries>();
        }
    }
}

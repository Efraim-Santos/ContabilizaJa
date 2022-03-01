using ContabilizaJa.Movimentacao.Data;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ContabilizaJa.WebApp.Configuration
{
    public static class ConfigurationServices
    {
        public static void ResolveDependencyInjection(IServiceCollection services)
        {
            services.AddScoped<IExtratoBancarioRepository, ExtratoBancarioRepository>();
        }
    }
}

using Intertech.Facade.DapperParameters;
using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Infraestructure.Infraestructure;
using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Infraestructure.DI
{
    [ExcludeFromCodeCoverage]
    public static class IoC
    {
        public static IServiceCollection AddInfraesctructure(this IServiceCollection services)
        {
            services.AddTransient<IConnectionFactory, ConnectionFactory>();
            services.AddTransient<IConnectionWrapper, ConnectionWrapper>();
            services.AddTransient<IDapperParameters, DapperParameters>();
            return services;
        }
    }
}

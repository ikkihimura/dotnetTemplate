using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Application.Feature.Interfaces;
using My.Custom.Template.Application.Feature.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Application.DI
{
    public static class IoC
    {

        public static IServiceCollection AddApplicationCore(this IServiceCollection services)
        {
            var assembly = typeof(IoC).Assembly;
            services.AddMediatR(configuration =>
            {
                configuration.RegisterServicesFromAssemblies(assembly);

            });
            services.AddTransient<IDomainNameService, DomainNameService>();

            return services;
        }

    }
}

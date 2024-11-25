using Microsoft.Extensions.DependencyInjection;
using My.Custom.Template.Presentation.Controllers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace My.Custom.Template.Presentation.Extensions
{
    public static class IoC
    {
        public static IServiceCollection AddPresentationModule(this IServiceCollection services)
        {
            services
                .AddMvcCore()
                .AddApplicationPart(typeof(DomainNameController).Assembly)//You can add as many as you want
                .AddControllersAsServices();


            return services;
        }
    }
}

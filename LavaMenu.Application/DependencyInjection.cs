using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Products.Command;
using LavaMenu.Application.Common.File;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            services.Add(new ServiceDescriptor(typeof(IworkFiles), typeof(ImageFiles), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAddProductItem), typeof(AddProductItem), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAddCategury), typeof(AddCategury), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetAllCategureis), typeof(GetAllCategury), ServiceLifetime.Scoped));
        }
    }
}

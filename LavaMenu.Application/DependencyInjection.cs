using LavaMenu.Application.Application.Interfaces.FacadeDesignPattern;
using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Application.Services.Categuries.FacadeDesign;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Products.Command;
using LavaMenu.Application.Application.Services.Products.FacadeDesign;
using LavaMenu.Application.Application.Services.Products.query;
using LavaMenu.Application.Common.File;
using Microsoft.Extensions.DependencyInjection;

namespace LavaMenu.Application
{
    public static class DependencyInjection
    {
        public static void AddApplicationServices(this IServiceCollection services)
        {
            ////////////////////////////////////////////////////////categury services
            services.Add(new ServiceDescriptor(typeof(IworkFiles), typeof(ImageFiles), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAddCategury), typeof(AddCategury), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetAllCategureis), typeof(GetAllCategury), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IChangeCateguryStatus), typeof(ChangeCateguryStatus), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetSingleCategury), typeof(GetSingleCategury), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEditCateguryService), typeof(EditCateguryService), ServiceLifetime.Scoped));
            /////////////////////////////////////////////////////////product services
            services.Add(new ServiceDescriptor(typeof(IAddProductService), typeof(AddProductService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IAnyProductExistanceService), typeof(AnyProductExistanceService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetAllProduct), typeof(GetAllProduct), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IChangeProductStatus), typeof(ChangeProductStatus), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IGetSingleProductService), typeof(GetSingleProductService), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IEditProductService), typeof(EditProductService), ServiceLifetime.Scoped));
            //facade design pattern rigestration 
            services.Add(new ServiceDescriptor(typeof(ICateguryFacad), typeof(CateguryFacad), ServiceLifetime.Scoped));
            services.Add(new ServiceDescriptor(typeof(IProductFacad), typeof(ProductFacad), ServiceLifetime.Scoped));
        }
    }
}

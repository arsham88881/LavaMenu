using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Products.query;
using Microsoft.Extensions.Configuration;

namespace LavaMenu.Application.Application.Interfaces.FacadeDesignPattern
{
    public interface ICateguryFacad
    {
        IAddCategury addCategury { get; }
        IChangeCateguryStatus changeCateguryStatus { get; }
        IGetAllCategureis getAllCategureis { get; }
        IGetSingleCategury getSingleCategury { get; }
        IEditCateguryService editCateguryService { get; }
        IHardDeleteCateguryService HardDeleteCategury { get; }
        ISoftDeleteCateguryService SoftDeleteCategury { get; }
        IGetProductWithNullCateguryService ProductWithoutCategury { get; }

        IAddProductToCategury AddProductToCategury { get; }
    }
}

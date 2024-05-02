using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Products.Command;
using LavaMenu.Application.Application.Services.Products.query;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Interfaces.FacadeDesignPattern
{
    public interface IProductFacad
    {
        IAnyProductExistanceService AnyProductExist { get; }
        IGetAllCategureis getAllCategureis { get; }
        IAddProductService addProduct { get; }
        IChangeProductStatus ChangeStatus { get; }
        IGetAllProduct allProduct { get; }
        IGetSingleProductService SingleProduct { get; }
        IEditProductService EditProduct { get; }
    }
}

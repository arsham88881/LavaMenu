using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Viewcompnent
{
    public class ShowCateguryCustomerViewComponent : ViewComponent
    {

        private readonly IGetAllCategureis _getAllCategureis;
        public ShowCateguryCustomerViewComponent(IGetAllCategureis getAllCategureis)
        {
            _getAllCategureis = getAllCategureis;
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {

            var list = _getAllCategureis.Excute().Where(p => p.IsAvailable == true).ToList<ProductCategury>();
            return await Task.FromResult((IViewComponentResult)View("ShowCateguryCustomer", list));
        }
    }
}

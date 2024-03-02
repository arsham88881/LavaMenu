using LavaMenu.Application.Application.Services.Categuries.query;
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

            var list = _getAllCategureis.Excute();
            return await Task.FromResult((IViewComponentResult)View("ShowCateguryCustomer", list));
        }
    }
}

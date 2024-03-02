using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Viewcompnent
{
    public class AddItemViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync()
        {

            return await Task.FromResult((IViewComponentResult)View("AddItem"));
        }
    }
}

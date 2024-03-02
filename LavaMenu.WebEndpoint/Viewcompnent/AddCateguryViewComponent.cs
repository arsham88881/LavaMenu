using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Viewcompnent
{
    public class AddCateguryViewComponent :ViewComponent
    {
        public AddCateguryViewComponent()
        {
            
        }
        public async Task<IViewComponentResult> InvokeAsync()
        {
            return await Task.FromResult((IViewComponentResult)View("AddCategury"));
        }
    }
}

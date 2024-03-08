using LavaMenu.Application.Common.ResultDTO;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Viewcompnent
{
    public class ShowGlobalResultViewComponent : ViewComponent
    {
        public async Task<IViewComponentResult> InvokeAsync(GlobalResultDTO? result )
        {
            return await Task.FromResult((IViewComponentResult) View("ShowGlobalResult",result));
        }
    }
}

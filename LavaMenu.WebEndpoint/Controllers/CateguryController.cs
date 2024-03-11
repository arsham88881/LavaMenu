using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    public class CateguryController : Controller
    {
        private readonly IAddCategury _addCategury;
        public CateguryController(IAddCategury addCategury)
        {
            _addCategury = addCategury;
        }
        [HttpGet]
        public IActionResult Index()
        {
            ViewData["addCateguryResult"] = new GlobalResultDTO() { IsSuccess = false, Message = "nothing" };

            return View();
        }
        [Route("/categury/Index")]
        [HttpPost]
        public async Task<ActionResult<GlobalResultDTO>> Index(addCateguryModel otherData , IFormFile Image)
        {
            int count = Request.Form.Files.Count;  ///count is ziro
            //IFormFile image = Request.Form.Files[0]; //get exception because count of file is ziro
            var request = new AddCateguryRequestDTO()
            {
                Name = otherData.Name,
                Image = Image
            };
            var result = _addCategury.Excute(request);

            return await Task.FromResult(result.Result);
        }
    }
}

using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;


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
        //[Route("/categury/Index")]
        [HttpPost]
        public async Task<ActionResult<GlobalResultDTO>> Index(string name , IFormFile Image)
        {
            int count = Request.Form.Files.Count; ///count is ziro

            var request = new AddCateguryRequestDTO()
            {
                Name = name,
                Image = Image
            };
            var result = _addCategury.Excute(request);

            return await Task.FromResult(result.Result);
        }

    }
}

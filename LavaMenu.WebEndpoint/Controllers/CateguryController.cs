using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;
using System.IdentityModel.Tokens.Jwt;
using System.Text.Json;


namespace LavaMenu.WebEndpoint.Controllers
{
    [Route("/[Controller]")]
    public class CateguryController : Controller
    {
        private readonly IAddCategury _addCategury;
        public CateguryController(IAddCategury addCategury)
        {
            _addCategury = addCategury;
        }
        [HttpGet]
        public IActionResult AddCategury()
        {
            return View();
        }
        [HttpPost]
        public async Task<ActionResult<GlobalResultDTO>> AddCategury(string name, IFormFile Image)
        {

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

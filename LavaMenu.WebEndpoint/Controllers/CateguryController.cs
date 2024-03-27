using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Common.AES;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Components.Web;
using Microsoft.AspNetCore.Mvc;
using Microsoft.VisualBasic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.AccessControl;
using System.Text.Json;


namespace LavaMenu.WebEndpoint.Controllers
{

    //[Route("/[Controller]")]
    public class CateguryController : Controller
    {
        private readonly IAddCategury _addCategury;
        private readonly IChangeCateguryStatus _changeStatus;
        private readonly IGetAllCategureis _allCategureis;
        private readonly IConfiguration _configure;

        public CateguryController(IAddCategury addCategury, IChangeCateguryStatus changeStatus , IGetAllCategureis allCategureis, IConfiguration configure)
        {
            _addCategury = addCategury;
            _allCategureis = allCategureis;
            _changeStatus = changeStatus;
            _configure = configure;
        }
        //[HttpGet("/{ID}")]
        //[Route("/[controller]/[action]/{ID}")]

        [HttpGet]
        public async Task<ActionResult<string>> ChangeStatus(string ID)
        {
            //var result = _changeStatus.Excute(ID.DecryptStringAES(_configure["secretKeyAES"]));

            //return await Task.FromResult(result.Result); //bool return

            return await Task.FromResult(ID.DecryptStringAES(_configure["secretKeyAES"]));
        }
        /// get:  Categury/showAllCategury
        [HttpGet]
        public IActionResult showAllCategury()
        {
            var list = _allCategureis.Excute();
            List<ShowCateguryModel> showList = new List<ShowCateguryModel>();
            foreach (var item in list)
            {
                showList.Add(new ShowCateguryModel()
                {
                    CateguryId = item.CateguryId.ToString().EncryptStringAES(_configure["secretKeyAES"]),
                    CateguryName = item.CateguryName,
                    SrcCategury = item.SrcCategury,
                    IsAvailable = item.IsAvailable
                });
            }

            return new JsonResult(showList);
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

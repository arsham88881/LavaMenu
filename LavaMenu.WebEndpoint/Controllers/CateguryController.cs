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

    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class CateguryController : ControllerBase
    {
        private readonly IAddCategury _addCategury;
        private readonly IChangeCateguryStatus _changeStatus;
        private readonly IGetAllCategureis _allCategureis;
        private readonly IConfiguration _configure;

        public CateguryController(IAddCategury addCategury, IChangeCateguryStatus changeStatus, IGetAllCategureis allCategureis, IConfiguration configure)
        {
            _addCategury = addCategury;
            _allCategureis = allCategureis;
            _changeStatus = changeStatus;
            _configure = configure;
        }

        /// post:  api/Categury/ChangeStatus
        [HttpPost]
        public async Task<bool> ChangeStatus([FromBody]string ID)
        {
            var result = await  _changeStatus.Excute(ID.DecryptStringAES(_configure["secretKeyAES"]));

            return result; //bool return

        }
        /// get:  api/Categury/showAllCategury
        [HttpGet]
        public async Task<List<ShowCateguryModel>> GetAllCategury()
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

            return await Task.FromResult(showList);
        }
        /// post:  api/Categury/AddCategury    
        [HttpPost]
        public async Task<GlobalResultDTO> AddCategury([FromForm]string name,[FromForm] IFormFile Image)
        {

            var request = new AddCateguryRequestDTO()
            {
                Name = name,
                Image = Image
            };
            var result = await _addCategury.Excute(request);

            return await Task.FromResult(result);
        }

    }
}

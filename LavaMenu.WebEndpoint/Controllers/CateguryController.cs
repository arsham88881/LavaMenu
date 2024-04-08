using LavaMenu.Application.Application.Interfaces.FacadeDesignPattern;
using LavaMenu.Application.Common.EncryptionAlgorithem;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;


namespace LavaMenu.WebEndpoint.Controllers
{

    [ApiController]
    [Route("api/[Controller]/[action]")]
    public class CateguryController : ControllerBase
    {
        private readonly IConfiguration _configure;
        private readonly ICateguryFacad _categuryFacad;

        public CateguryController(IConfiguration configuration, ICateguryFacad categuryFacad)
        {
            _configure = configuration;
            _categuryFacad = categuryFacad;
        }
        /// PUT:  api/Categury/EditCategury?id={}&name={}
        [HttpPut]
        public async Task<GlobalResultDTO> EditCategury(CateguryRequestDTO UpdateCategury,string ID)
        {
           
            var result = await _categuryFacad.editCateguryService.excute(ID.DecryptStringDES(_configure["secretKey"]), UpdateCategury);

            return result;
        }
        /// GET:  api/Categury/GetSingleCategury?id
        [HttpGet]
        public async Task<ShowCateguryModel> GetSingleCategury(string ID)
        {
            var result = await _categuryFacad.getSingleCategury.Excute(ID.DecryptStringDES(_configure["secretKey"]));

            return new ShowCateguryModel()
            {
                CateguryId = result.Value.CateguryId.ToString().EncryptStringDES(_configure["secretKey"]),
                CateguryName = result.Value.CateguryName,
                SrcCategury = result.Value.SrcCategury,
                IsAvailable = result.Value.IsAvailable,
            };

        }
        /// GET:  api/Categury/ChangeStatus?id
        [HttpGet]
        public async Task<bool> ChangeStatus(string ID)
        {
            var result = await _categuryFacad.changeCateguryStatus.Excute(ID.DecryptStringDES(_configure["secretKey"]));

            return result; //bool return

        }
        /// GET:  api/Categury/showAllCategury
        [HttpGet]
        public async Task<List<ShowCateguryModel>> GetAllCategury()
        {
            var list = _categuryFacad.getAllCategureis.Excute();
            List<ShowCateguryModel> showList = new List<ShowCateguryModel>();
            foreach (var item in list)
            {
                showList.Add(new ShowCateguryModel()
                {
                    CateguryId = item.CateguryId.ToString().EncryptStringDES(_configure["secretKey"]),
                    CateguryName = item.CateguryName,
                    SrcCategury = item.SrcCategury,
                    IsAvailable = item.IsAvailable
                });
            }

            return await Task.FromResult(showList);
        }
        /// post:  api/Categury/AddCategury    
        [HttpPost]
        public async Task<GlobalResultDTO> AddCategury([FromForm] string name, [FromForm] IFormFile Image)
        {

            var request = new CateguryRequestDTO()
            {
                Name = name,
                Image = Image
            };
            var result = await _categuryFacad.addCategury.Excute(request);

            return await Task.FromResult(result);
        }

    }
}

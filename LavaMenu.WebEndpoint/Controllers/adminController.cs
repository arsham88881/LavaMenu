using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Common.AES;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    public class adminController : Controller
    {
        private readonly IGetAllCategureis _allCategureis;
        private readonly IConfiguration _configure;
        public adminController(IGetAllCategureis allCategureis, IConfiguration configure)
        {
            _allCategureis = allCategureis;
            _configure = configure;

        }
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categury()
        {
            //var configure = new ConfigurationBuilder().AddJsonFile("appsettings.json", optional: true, reloadOnChange: true).Build();

            //var list = _allCategureis.Excute();
            //List<ShowCateguryModel> showList = new List<ShowCateguryModel>();
            //foreach (var item in list)
            //{
            //    showList.Add(new ShowCateguryModel()
            //    {
            //        CateguryId = item.CateguryId.ToString().EncryptStringAES(_configure["secretKeyAES"]),
            //        CateguryName = item.CateguryName,
            //        SrcCategury = item.SrcCategury
            //    });
            //}
            return View();
        }
    }
}

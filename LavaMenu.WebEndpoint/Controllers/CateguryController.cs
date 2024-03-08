using LavaMenu.Application.Application.Services.Categuries.command;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Common.ResultDTO;
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
        public  IActionResult Index()
        {
            ViewData["addCateguryResult"] = new GlobalResultDTO() {IsSuccess = false , Message = "nothing" };

            return View();
        }
        [HttpPost]
        public  IActionResult Index( AddCateguryRequestDTO categury)
        {
            int count = Request.Form.Files.Count;  ///count is ziro
            //IFormFile image = Request.Form.Files[0]; //get exception because count of file is ziro

           var result =  _addCategury.Excute(categury);

            if(!result.IsCompleted)
            {
                ViewData["addCateguryResult"] =  result.Result;
                return View();
            }
            return Redirect("/admin/index");
        }
    }
}

using LavaMenu.Application.Application.Services.Categuries.query;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGetAllCategureis _getAllCategureis;
        public CustomerController(IGetAllCategureis getAllCategureis) { 
            _getAllCategureis  = getAllCategureis;
        }
        public IActionResult Index(int categury = 1)
        {

            return View();
        }
    }
}

using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.WebEndpoint.Models;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    public class adminController : Controller
    {
        public IActionResult Index()
        {
            return View();
        }
        public IActionResult Categury()
        {
            return View();
        }
        public IActionResult Product()
        {
            return View();
        }
    }
}

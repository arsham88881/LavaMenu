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

        //[HttpPost]
        //public ActionResult Index(AddProductModel model)
        //{
        //    return View();
        //}
    }
}

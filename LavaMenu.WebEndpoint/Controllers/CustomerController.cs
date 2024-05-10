using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Customer.queries;
using LavaMenu.Application.Common.EncryptionAlgorithem;
using LavaMenu.Application.Domain.Entitys;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    public class CustomerController : Controller
    {
        private readonly IGetAllCategureis _getAllCategureis;
        private readonly IConfiguration _configure;
        private readonly IProductsFromCateguryService _ProductsfromCategury;
        public CustomerController(IGetAllCategureis getAllCategureis, IConfiguration configure, IProductsFromCateguryService productsfromCategury)
        {
            _getAllCategureis = getAllCategureis;
            _configure = configure;
            _ProductsfromCategury = productsfromCategury;
        }
        public async Task<IActionResult> Index(string categuryID = null)
        {
            var DefalutCategury = _getAllCategureis.Excute()
                 .Where(p => p.IsAvailable == true)
                 .FirstOrDefault() ?? new ProductCategury
                 {
                     CateguryId = 0,
                     CateguryName = "null",
                     SrcCategury = "null"
                 };
            string? decriptedCateguryId = null;
            if (categuryID != null)
            {
                decriptedCateguryId = categuryID.DecryptStringDES(_configure["secretKey"]);
            }
            var Id = (categuryID == null) ? DefalutCategury.CateguryId : Convert.ToInt32(decriptedCateguryId);

            List<Product> Products = await _ProductsfromCategury.GetProductsAsync(Id);

            return View(Products);
        }
    }
}

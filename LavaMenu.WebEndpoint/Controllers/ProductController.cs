using LavaMenu.Application.Application.Interfaces.FacadeDesignPattern;
using LavaMenu.Application.Common.RequestDTO;
using LavaMenu.Application.Domain.Entitys;
using LavaMenu.WebEndpoint.Models.Product;
using Microsoft.AspNetCore.Mvc;

namespace LavaMenu.WebEndpoint.Controllers
{
    [ApiController]
    [Route("api/[controller]/[action]")]
    public class ProductController : Controller
    {
        private readonly IProductFacad _Facad;
        public ProductController(IProductFacad facad)
        {
            _Facad = facad;
        }

        ///GET : api/Product/GetAllCateguryAddProduct
        [HttpGet]
        public async Task<IActionResult> GetAllCateguryAddProduct()
        {
            var result = _Facad.getAllCategureis.Excute().Select(p => new { CateguryId = p.CateguryId, CateguryName = p.CateguryName }).ToList();

            return Ok(result);
        }
        ///GET : api/Product/GetSingleProduct?ProductId={id} 
        public async Task<IActionResult> GetSingleProduct(string ProductId)
        {
            if (ProductId == null) { return BadRequest(); }

            var result = await _Facad.SingleProduct.GetProductAsync(ProductId);

            return Ok(result);
        }
        /// POST : api/Product/EditProduct 
        [HttpPost]
        public async Task<IActionResult> EditProduct([FromForm] ProductViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest("درخواست ناموفق"); }

            var result = await _Facad.EditProduct.EditProductAsync(new Product
            {
                ProductId = model.ProductId,
                ProductTitle = model.ProductTitle,
                ProductDescription = model.ProductDescription,
                productPrice = model.productPrice,
                IsWithDiscount = model.IsWithDiscount,
                DiscountAmountOption = model.AfterDiscountPrice,
                CateguryId = model.CateguryId

            }, model.file);

            return Ok(result);
        }

        public async Task<IActionResult> PostProduct([FromForm] ProductViewModel model)
        {
            if (!ModelState.IsValid) { return BadRequest("ورودی های اجباری دریافت نشده است"); }

            var Request = new AddProductRequestDTO
            {
                ProductTitle = model.ProductTitle,
                ProductDescription = model.ProductDescription,
                productPrice = model.productPrice,
                IsWithDiscount = model.IsWithDiscount,
                AfterDiscountPrice = model.AfterDiscountPrice,
                CateguryId = model.CateguryId,
                Image = model.file
            };
            var result = await _Facad.addProduct.PostSingleProdut(Request);

            return Ok(result);

        }
        ///GET : api/Product/ChangeStatus?ProductId={id}
        [HttpGet]
        public async Task<IActionResult> ChangeStatus(string ProductId)
        {
            var result = await _Facad.ChangeStatus.ActivationAsync(ProductId);

            return Ok(result);
        }
        /// POST : api/Product/IsAnyProduct
        [HttpPost]
        public async Task<IActionResult> IsAnyProduct(string ProductTitle)
        {
            var any = _Facad.AnyProductExist.ExstanceByTitle(ProductTitle);
            if (!any)
            {
                return Json(true);
            }
            else
            {
                return Json("نام محصول مورد نظر از قبل ثبت شده است");
            }
        }

        /// GET : api/Product/GetAllProductAdminPanel 
        [HttpGet]
        public async Task<IActionResult> GetAllProductAdminPanel()
        {
            var response = await _Facad.allProduct.GetAllAsync();

            var result = response.Select(x => new
            {
                ProductId = x.ProductId,
                ProductTitle = x.ProductTitle,
                ProductDescription = x.ProductDescription,
                productPrice = x.productPrice,
                IsWithDiscount = x.IsWithDiscount,
                DiscountAmountOption = x.DiscountAmountOption,
                IsActive = x.IsActive,
                PictureSrc = x.PictureSrc,
                CateguryId = (x.CateguryId == null) ? 0 : x.CateguryId,
                categuryName = (x.CateguryId == null) ? "بدون‌دسته‌بندی" : x.categury.CateguryName,
            });

            return Ok(result);
        }

        /// DELETE : api/Product/DeleteHardProduct
        [HttpDelete]
        public async Task<IActionResult> DeleteHardProduct(string ProductId)
        {
            var result = await _Facad.HardDelete.DeleteProductAsync(ProductId);

            return Ok(result);
        }
    }
}

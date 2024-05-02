using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Application.Interfaces.FacadeDesignPattern;
using LavaMenu.Application.Application.Services.Categuries.query;
using LavaMenu.Application.Application.Services.Products.Command;
using LavaMenu.Application.Application.Services.Products.query;
using LavaMenu.Application.Common.File;

namespace LavaMenu.Application.Application.Services.Products.FacadeDesign
{
    public class ProductFacad : IProductFacad
    {
        private readonly Idb _db;
        private readonly IworkFiles _workFile;

        public ProductFacad(Idb db, IworkFiles workFile)
        {
            _db = db;
            _workFile = workFile;
        }
        private IAnyProductExistanceService _productExistanceService;
        public IAnyProductExistanceService AnyProductExist
        {
            get
            {
                return _productExistanceService = _productExistanceService ?? new AnyProductExistanceService(_db);
            }
        }

        IGetAllCategureis _getAllCategureis;
        public IGetAllCategureis getAllCategureis
        {
            get
            {
                return _getAllCategureis = _getAllCategureis ?? new GetAllCategury(_db);
            }
        }

        IAddProductService _addProductService;
        public IAddProductService addProduct
        {
            get
            {
                return _addProductService = _addProductService ?? new AddProductService(_workFile, _db);
            }
        }
        IGetAllProduct _getAllProduct;
        public IGetAllProduct allProduct
        {
            get
            {
                return _getAllProduct = _getAllProduct ?? new GetAllProduct(_db);
            }
        }

        private IChangeProductStatus _ProductStatus;
        public IChangeProductStatus ChangeStatus
        {
            get
            {
                return _ProductStatus = _ProductStatus ?? new ChangeProductStatus(_db);
            }
        }

        private IGetSingleProductService _singleProduct;
        public IGetSingleProductService SingleProduct
        {
            get
            {
                return _singleProduct = _singleProduct ?? new GetSingleProductService(_db);
            }
        }

        private IEditProductService _editProduct;
        public IEditProductService EditProduct
        {
            get
            {
                return _editProduct = _editProduct ?? new EditProductService(_workFile, _db);
            }
        }
    }
}

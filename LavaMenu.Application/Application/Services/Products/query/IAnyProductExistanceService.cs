using LavaMenu.Application.Application.Interfaces;

namespace LavaMenu.Application.Application.Services.Products.query
{

    public interface IAnyProductExistanceService
    {
        public bool ExstanceByTitle(string ProductTitle);
    }
    public class AnyProductExistanceService : IAnyProductExistanceService
    {
        private readonly Idb _db;

        public AnyProductExistanceService(Idb db)
        {
            _db = db;
        }

        public bool ExstanceByTitle(string ProductTitle)
        {
            bool result = _db.Products.Any(p => p.ProductTitle == ProductTitle);

            return result;
        }
    }
}

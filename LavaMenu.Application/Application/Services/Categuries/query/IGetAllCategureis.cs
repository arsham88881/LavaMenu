using LavaMenu.Application.Application.Interfaces;
using LavaMenu.Application.Domain.Entitys;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace LavaMenu.Application.Application.Services.Categuries.query
{
    public interface IGetAllCategureis
    {
        List<ProductCategury> Excute();
    }

    public class GetAllCategury : IGetAllCategureis
    {
        private readonly Idb _db;
        public GetAllCategury(Idb db)
        {
            _db = db;
        }
        public List<ProductCategury> Excute()
        {
            var list = _db.Categories.AsEnumerable().ToList<ProductCategury>();

            return list;
        }
    }
}

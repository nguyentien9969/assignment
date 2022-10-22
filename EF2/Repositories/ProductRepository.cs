using EF2.Data;
using EF2.Models;
using EF2.Repositories.Interfaces;
using Enitity_Framework.Repositories;

namespace EF2.Repositories
{
    public class ProductRepository : BaseRepository<Product>, IProductRepository
    {
        public ProductRepository(ProductStoreContext context) : base(context)
        {
        }
    }
}
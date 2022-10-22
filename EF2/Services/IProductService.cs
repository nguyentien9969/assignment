using EF2.DTOs;
using EF2.DTOs.Product;

namespace EF2.Services
{
    public interface IProductService 
    {
        AddProductRespone Create(AddProductRequest addRequest);
        IEnumerable<GetProductRespone> GetAll();
        GetProductRespone GetById(int id);
        UpdateProductRespone Update(int id,UpdateProductRequest updateRequest);
        bool Delete(int id);
    }
}
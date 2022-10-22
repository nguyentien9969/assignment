using EF2.DTOs;
using EF2.DTOs.Product;
using EF2.Models;
using EF2.Repositories.Interfaces;

namespace EF2.Services
{
    public class ProductService : IProductService
    {
        private readonly IProductRepository _productRepo;
        private readonly ICategoryRepository _cateRepo;

        public ProductService(IProductRepository repo, ICategoryRepository cateRepo)
        {
            _productRepo = repo;
            _cateRepo = cateRepo;
        }

        public AddProductRespone Create(AddProductRequest addRequest)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                var category = _cateRepo.Get(x => x.Id == addRequest.CategoryId);

                if (category == null) return null;

                var product = new Product
                {
                    Name = addRequest.Name,
                    Manufacture = addRequest.Manufacture,
                    CategoryId = addRequest.CategoryId
                };

                var createdProduct = _productRepo.Create(product);
                _productRepo.SaveChanges();

                transaction.Commit();

                return new AddProductRespone
                {
                    Id = createdProduct.Id,
                    Name = createdProduct.Name
                };
            }
        }

        public bool Delete(int id)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var product = _productRepo.Get(product => product.Id == id);

                    if (product == null)
                    {
                        return false;
                    }

                    _productRepo.Delete(product);
                    _productRepo.SaveChanges();

                    transaction.Commit();

                    return true;
                }

                catch (System.Exception)
                {
                    transaction.RollBack();

                    return false;
                }
            }
        }

        public IEnumerable<GetProductRespone> GetAll()
        {
            return _productRepo
            .GetAll(null)
            .Select(product => new GetProductRespone
            {
                Id = product.Id,
                Name = product.Name,
                Manufacture = product.Manufacture,
                CategoryId = product.CategoryId
            });
        }

        public GetProductRespone GetById(int id)
        {
            var product = _productRepo.Get(product => product.Id == id);

            return new GetProductRespone
            {
                Id = product.Id,
                Name = product.Name,
                Manufacture = product.Manufacture,
                CategoryId = product.CategoryId
            };
        }

        public UpdateProductRespone Update(int id, UpdateProductRequest updateRequest)
        {
            using (var transaction = _productRepo.DatabaseTransaction())
            {
                try
                {
                    var product = _productRepo.Get(p => p.Id == id);
                    if (product == null)
                    {
                        return null;
                    }

                    var category = _cateRepo.Get(c => c.Id == updateRequest.CategoryId);

                    if (category == null)
                    {
                        return null;
                    }

                    product.Name = updateRequest.Name;
                    product.Manufacture = updateRequest.Manufacture;
                    product.CategoryId = updateRequest.CategoryId;

                    var updatedproduct = _productRepo.Update(product);

                    _cateRepo.SaveChanges();
                    _productRepo.SaveChanges();
                    transaction.Commit();

                    return new UpdateProductRespone
                    {
                        Id = updatedproduct.Id,
                        Name = updatedproduct.Name,
                        Manufacture = product.Manufacture,
                        CategoryId = product.CategoryId
                    };
                }

                catch (System.Exception)
                {
                    transaction.RollBack();
                    return null;
                }
            }
        }
    }
}
using EF2.DTOs.Category;
using EF2.Models;
using EF2.Repositories.Interfaces;

namespace EF2.Services
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepo;

        public CategoryService(ICategoryRepository categoryRepo)
        {
            _categoryRepo = categoryRepo;
        }

        public AddCategoryRespone? Create(AddCategoryRequest requestModel)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {

                var newcategory = new Category
                {
                    Name = requestModel.Name
                };

                var createdCategory = _categoryRepo.Create(newcategory);

                if (createdCategory == null)
                {
                    transaction.RollBack();
                }

                _categoryRepo.SaveChanges();

                transaction.Commit();

                return new AddCategoryRespone
                {
                    Id = createdCategory.Id,
                    Name = createdCategory.Name
                };

            }
        }

        public bool Delete(int id)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(category => category.Id == id);

                    if (category == null)
                    {
                        return false;
                    }

                    _categoryRepo.Delete(category);
                    _categoryRepo.SaveChanges();
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

        public IEnumerable<GetCategoryRespone> GetAll()
        {
            return _categoryRepo
                .GetAll(null)
                .Select(category => new GetCategoryRespone
                {
                    Id = category.Id,
                    Name = category.Name
                });
        }

        public GetCategoryRespone? GetById(int id)
        {
            var category = _categoryRepo.Get(category => category.Id == id);

            if (category == null)
            {
                return null;
            }

            return new GetCategoryRespone
            {
                Id = category.Id,
                Name = category.Name
            };
        }

        public UpdateCategoryRespone? Update(int id, UpdateCategoryRequest requestModel)
        {
            using (var transaction = _categoryRepo.DatabaseTransaction())
            {
                try
                {
                    var category = _categoryRepo.Get(category => category.Id == id);

                    if (category == null)
                    {
                        return null;
                    }

                    category.Name = requestModel.Name;

                    var updatedcategory = _categoryRepo.Update(category);

                    _categoryRepo.SaveChanges();
                    transaction.Commit();

                    return new UpdateCategoryRespone
                    {
                        Id = updatedcategory.Id,
                        Name = updatedcategory.Name
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


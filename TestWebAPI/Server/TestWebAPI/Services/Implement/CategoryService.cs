using Test.Data.Entities;
using Test.Data.Repositories.Interface;
using TestWebAPI.DTOS.Book;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Services.Implement
{
    public class CategoryService : ICategoryService
    {
        private readonly ICategoryRepository _categoryRepository;
        public CategoryService(ICategoryRepository categoryRepository)
        {
            _categoryRepository = categoryRepository;
        }

        public AddCategoryRespone Add(AddCategoryRequest request)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try 
            {
                if (request == null) return null;

                var newCategory = new Category
                {
                    Name = request.Name,
                    Description = request.Description
                };

                _categoryRepository.Create(newCategory);
                _categoryRepository.SaveChanges();
                transaction.Commit();

                return new AddCategoryRespone
                {
                    Name = newCategory.Name,
                    Id = newCategory.Id,
                    Description = newCategory.Description
                };
            }
            catch (Exception ex) 
            {
                transaction.RollBack();
                return null;
            }
        }

        public bool Delete(int id)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.GetOne(x => x.Id == id);

                if (category == null) return false;

                _categoryRepository.Delete(category);
                _categoryRepository.SaveChanges();
                transaction.Commit();

                return true;
            }
            catch (Exception ex)
            {
                transaction.RollBack();
                return false;
            }
        }

        public IEnumerable<GetCategoryRespone> GetAll()
        {
            using (var transaction = _categoryRepository.DatabaseTransaction())

                try
                {
                    var categorys = _categoryRepository.GetAll().Select(category => new GetCategoryRespone
                    {
                        Name = category.Name,
                        Description = category.Description,
                        Id = category.Id
                    });

                    transaction.Commit();

                    return categorys;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public GetCategoryRespone GetOne(int id)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.GetOne(x => x.Id == id);

                if (category == null) return null;

                return new GetCategoryRespone
                {
                    Id = category.Id,
                    Name = category.Name,
                    Description = category.Description
                };


            }
            catch (Exception ex)
            {
                return null;
            }
        }

        public UpdateCategoryRespone Update(UpdateCategoryRequest request)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.GetOne(x => x.Id == request.Id);
                
                if (category == null) return null;

                category.Name = request.Name;
                category.Description = request.Description;

                var updatedCategory = _categoryRepository.Update(category);
                _categoryRepository.SaveChanges();
                
                transaction.Commit();

                return new UpdateCategoryRespone
                {
                    Id = updatedCategory.Id,
                    Description = updatedCategory.Description,
                    Name = updatedCategory.Name,
                };
                
            }
            catch (Exception ex)
            {
                transaction.RollBack();
                return null;
            }
        }
    }
}

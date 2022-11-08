﻿using Test.Data.Entities;
using Test.Data.Repositories.Implement;
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

        public AddCategoryRespone AddBook(AddCategoryRequest request)
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

        public bool DeleteBook(int id)
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

        public IEnumerable<GetCategoryRespone> GetAllBook()
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

        public GetCategoryRespone GetBook(int id)
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

        public UpdateCategoryRespone UpdateBook(UpdateCategoryRequest request)
        {
            using var transaction = _categoryRepository.DatabaseTransaction();
            try
            {
                var category = _categoryRepository.GetOne(x => x.Id == request.Id);
                
                if (category == null) return null;

                var updateCategory = new Category
                {
                    Name=request.Name,
                    Description =request.Description,
                };

                _categoryRepository.Update(updateCategory);
                _categoryRepository.SaveChanges();
                transaction.Commit();

                return new UpdateCategoryRespone
                {
                    Description = updateCategory.Description,
                    Name = updateCategory.Name,
                    Id = updateCategory.Id
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

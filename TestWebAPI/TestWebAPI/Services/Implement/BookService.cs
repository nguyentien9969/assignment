using System.Net;
using Test.Data.Entities;
using Test.Data.Repositories.Implement;
using Test.Data.Repositories.Interface;
using TestWebAPI.DTOS.Book;
using TestWebAPI.DTOS.Category;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Services.Implement
{
    public class BookService : IBookService
    {
        private readonly IBookRepository _bookRepository;
        private readonly ICategoryRepository _categoryRepository;
        public BookService(IBookRepository bookRepository, ICategoryRepository categoryRepository)
        {
            _bookRepository = bookRepository;
            _categoryRepository = categoryRepository;

        }

        public AddBookRespone AddBook(AddBookRequest request)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())
                try
            {
                var categoryIds = request.CategoryIds;
                var catergories = _categoryRepository.GetAllWithPredicate(x => categoryIds.Contains(x.Id)) as List<Category>;

                if (catergories == null) return null;

                var newbook = new Book
                {
                    Name = request.Name,
                    Description = request.Description,
                    Categories = catergories
                };

                _categoryRepository.SaveChanges();
                _bookRepository.Create(newbook);
                _bookRepository.SaveChanges();
                transaction.Commit();



                return new AddBookRespone
                {
                    Name = newbook.Name,
                    Description = newbook.Description,
                    Categories = catergories.Select(cat => new CategoryModel
                    {
                        Id = cat.Id,
                        Name = cat.Name
                    }).ToList()
                   
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
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var deleteBook = _bookRepository.GetOne(book => book.Id == id);

                    if (deleteBook != null)
                    {
                        _bookRepository.Delete(deleteBook);
                        _bookRepository.SaveChanges();
                        transaction.Commit();
                    }

                    return true;
                }
                catch
                {
                    transaction.RollBack();

                    return false;
                }
        }

        public IEnumerable<GetBookRespone> GetAll()
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var books = _bookRepository.GetAll().Select(book => new GetBookRespone
                    {
                        Name = book.Name,
                        Description = book.Description,
                        Id = book.Id
                    });

                    transaction.Commit();

                    return books;
                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }

        }

        public GetBookRespone GetBook(int id)
        {
            using (var transaction = _bookRepository.DatabaseTransaction())

                try
                {
                    var book = _bookRepository.GetOne(i => i.Id == id);

                    if (book != null)
                    {
                        transaction.Commit();

                        return new GetBookRespone
                        {
                            Id = book.Id,
                            Name = book.Name,

                        };
                    }

                    return null;

                }
                catch
                {
                    transaction.RollBack();

                    return null;
                }
        }

        public UpdateBookRespone UpdateBook(UpdateBookRequest request)
        {
            throw new NotImplementedException();
        }

        //public UpdateBookRespone UpdateBook(UpdateBookRequest request)
        //{
        //    using (var transaction = _bookRepository.DatabaseTransaction())
        //    {

        //    }

        //}
    }
}

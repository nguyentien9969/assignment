using Common.Enums;
using Test.Data.Entities;
using Test.Data.Repositories.Interface;
using TestWebAPI.DTOS.Book;
using TestWebAPI.DTOS.Person;
using TestWebAPI.Services.Interface;

namespace TestWebAPI.Services.Implement
{
    public class BookBorrowRequestService : IBookBorrowRequestService
    {
        private readonly IBookBorrowRequestRepository _bookBorrowRequestRepository;
        private readonly IBookRepository _bookRepository;

        public BookBorrowRequestService(IBookBorrowRequestRepository bookBorrowRequestRepository, IBookRepository bookRepository)
        {
            _bookBorrowRequestRepository = bookBorrowRequestRepository;
            _bookRepository = bookRepository;
        }

        public AddBookBorrowRespone Add(AddBookBorrowRequest request)
        {
            using var transaction = _bookBorrowRequestRepository.DatabaseTransaction();
            try 
            {
                var books = _bookRepository.GetAllWithPredicate(book => request.BooksId.Contains(book.Id)).ToList();
                if (books == null) return null;

                var newBookBorrowRequest = new BookBorrowRequest
                {
                    Books = books,
                    RequestStatus = RequestStatus.Waiting,
                    RequestAt = DateTime.Now,
                    RequestedBy = request.Requester.Id,
                };

                _bookBorrowRequestRepository.Create(newBookBorrowRequest);
                _bookBorrowRequestRepository.SaveChanges();
                transaction.Commit();

                return new AddBookBorrowRespone
                {
                    Id = newBookBorrowRequest.Id,
                    Status = newBookBorrowRequest.RequestStatus.ToString(),
                    RequestedBy = newBookBorrowRequest.RequestedBy,
                    RequestedAt = newBookBorrowRequest.RequestAt,
                    Books = newBookBorrowRequest.Books.Select(x => new BookModel
                    {
                        Id = x.Id,
                        Description = x.Description,
                        Name = x.Name
                    }).ToList()
                };
            }
            catch (Exception ex)
            {
                transaction.RollBack();
                return null;
            }
        }

        public ApproveBookBorrowRequestRespone Approve(ApproveBookBorrowRequestRequest request)
        {
            var transaction = _bookBorrowRequestRepository.DatabaseTransaction();
            try
            {
                var borrowRequest = _bookBorrowRequestRepository.GetOne(x => x.Id == request.Id);
                if (borrowRequest == null) return null;

                borrowRequest.RequestStatus = request.IsApproved
                    ? RequestStatus.Approved : RequestStatus.Rejected;
                borrowRequest.AprovedBy = request.Approver.Id;
                borrowRequest.ApproveAt = DateTime.Now;
                
                var updatedBorrowRequest = _bookBorrowRequestRepository.Update(borrowRequest);
                _bookBorrowRequestRepository.SaveChanges();
                transaction.Commit();



                return new ApproveBookBorrowRequestRespone
                {
                    Id = updatedBorrowRequest.Id,
                    Status = borrowRequest.RequestStatus.ToString(),
                    RequestedAt = borrowRequest.RequestAt,
                    //Approver = request.Approver,
                    //Books = borrowRequest.Books.Select(x => new BookModel
                    //{
                    //    Id = x.Id,
                    //    Description = x.Description,
                    //    Name = x.Name
                    //}).ToList()
                };
            }
            catch (Exception ex) 
            {
                transaction.RollBack();
                return null;
            } 
            
        }

        public string CheckRequestLimit(AddBookBorrowRequest request)
        {
            if (request == null) return null;
            var book = _bookRepository.GetAllWithPredicate(x => request.BooksId.Contains(x.Id));
            if (request.BooksId.Count() > 5) return "So luong sach Qua 5";

            var currentMonth = DateTime.Now.Day;

            var bookRequestsThisMonth = _bookBorrowRequestRepository
           .GetAllWithPredicate(br => br.RequestedBy == request.Requester.Id &&
                br.RequestAt.Month == currentMonth
                );

            if (bookRequestsThisMonth.Count() > 3) return "Ban da muon qua 3 lan";

            return null;

        }

        public IEnumerable<BookBorrowRequest> GetAll()
        {
            using var transaction = _bookBorrowRequestRepository.DatabaseTransaction();
            try
            {
                var borrowRequest = _bookBorrowRequestRepository.GetAll();
                
                return borrowRequest;              
            }
            catch (Exception ex )
            {
                transaction.RollBack();
                return null;
            }
        }

        public GetBookBorrowRequestRespone GetById(int id)
        {
            using var transaction = _bookBorrowRequestRepository.DatabaseTransaction();
            try 
            {
                var borrowRequest = _bookBorrowRequestRepository.GetOne(x => x.Id == id && x.Requester.Role == Role.Normal);
                if (borrowRequest == null) return null;

                _bookBorrowRequestRepository.SaveChanges();
                transaction.Commit();
                return new GetBookBorrowRequestRespone
                {
                    Id = borrowRequest.Id,
                    RequestedAt = borrowRequest.RequestAt,
                    ApprovedAt = borrowRequest.ApproveAt,
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


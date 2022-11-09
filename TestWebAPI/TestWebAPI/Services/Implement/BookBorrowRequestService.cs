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

                _bookBorrowRequestRepository.Update(borrowRequest);
                _bookBorrowRequestRepository.SaveChanges();
                transaction.Commit();

                var approver = new PersonModel
                {
                    Id = borrowRequest.Approver.Id,
                    Name = borrowRequest.Approver.Name,
                    Role = borrowRequest.Approver.Role
                };

                var requester = new PersonModel
                {
                    Id = borrowRequest.Requester.Id,
                    Name = borrowRequest.Requester.Name,
                    Role = borrowRequest.Requester.Role
                };

                return new ApproveBookBorrowRequestRespone
                {
                    Id = borrowRequest.Id,
                    Status = borrowRequest.RequestStatus.ToString(),
                    RequestedAt = borrowRequest.RequestAt,
                    Approver = approver,
                    Requester = requester,
                    Books = borrowRequest.Books.Select(x => new BookModel
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

        public string CheckRequestLimit(AddBookBorrowRequest request)
        {
            if (request == null) return null;
            var book = _bookRepository.GetAllWithPredicate(x => request.BooksId.Contains(x.Id));
            if (request.BooksId.Count() > 5) return "So luong sach Qua 5";

            var currentMonth = DateTime.Now.Day;

            var bookRequestsThisMonth = _bookBorrowRequestRepository
           .GetAllWithPredicate(x =>
               x.RequestedBy == request.Requester.Id &&
              currentMonth - x.RequestAt.Day < 30 );

            if (bookRequestsThisMonth.Count() > 3) return "Ban da muon qua 3 lan";

            return null;

        }

        public IEnumerable<BookBorrowRequest> GetAll()
        {
            using var transaction = _bookBorrowRequestRepository.DatabaseTransaction();
            try
            {
                var borrowRequest = _bookBorrowRequestRepository.GetAllWithPredicate(x => x.Requester.Role == Role.Normal);

                _bookBorrowRequestRepository.SaveChanges();
                transaction.Commit();
                
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
                   //
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


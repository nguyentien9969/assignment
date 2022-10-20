using Enitity_Framework.DTOs;
using Enitity_Framework.Models;
using Enitity_Framework.Services.Interfaces;
using Enitity_Framework.Repositories;

namespace Enitity_Framework.Services
{
    public class StudentServices : IStudentServices
    {
        private readonly IBaseRepository<Student> _studentRepository;
        public StudentServices(IStudentRepository studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public AddStudentRespone Create(AddStudentRequest addRequest)
        {
            var createStudent = new Student
            {
                FirstName = addRequest.FirstName,
                LastName = addRequest.LastName,
                State = addRequest.State,
                City = addRequest.City
            };

            var student = _studentRepository.Create(createStudent);

            _studentRepository.SaveChanges();

            return new AddStudentRespone
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
            };
        }

        public GetStudent GetById(int id)
        {
            var student = _studentRepository.Get(student => student.Id == id);
            return new GetStudent
            {
                Id = student.Id,
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City
            };
        }

        public IEnumerable<GetStudent> GetAll()
        {
            return _studentRepository.GetAll(t => true)
                                     .Select(student => new GetStudent
                                     {
                                         Id = student.Id,
                                         FirstName = student.FirstName,
                                         LastName = student.LastName,
                                         City = student.City,
                                     });
        }

        public UpdateStudentRespone Update(int id, UpdateStudentRequest updateRequest)
        {
            var student = _studentRepository.Get(student => student.Id == id);

            if (student == null) return null;

            {
                student.FirstName = updateRequest.FirstName;
                student.LastName = updateRequest.LastName;
                student.City = updateRequest.City;
                student.State = updateRequest.State;
            }

            _studentRepository.Update(student);
            _studentRepository.SaveChanges();

            return new UpdateStudentRespone
            {
                FirstName = student.FirstName,
                LastName = student.LastName,
                City = student.City,
                State = student.State
            };
        }
        public bool Delete(int id)
        {
            var student = _studentRepository.Get(s => s.Id == id);

            if (student == null) return false;

            _studentRepository.Delete(student);
            _studentRepository.SaveChanges();

            return true;
        }
    }
}
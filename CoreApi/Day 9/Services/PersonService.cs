using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Day_9.Models;
using Person = Day_9.Models.Person;


namespace Day_9.Services
{
    public class PersonService : IPersonService
    {
        private static List<Person> _peopleList = new List<Person>
        {
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Tin",
                LastName = "Nguyen Viet",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 2, 22),
                PhoneNumber = "",
                BirthPlace = "BacNinh",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Nguyen Ngoc",
                Gender = "Male",
                DateOfBirth = new DateTime(2003, 6, 13),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Minh",
                LastName = "Nguyen Tuan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 11, 14),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Huy",
                LastName = "Nguyen Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 1, 26),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Tien",
                LastName = "Nguyen Ngoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1987, 2, 5),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Long",
                LastName = "Lai Quoc",
                Gender = "Male",
                DateOfBirth = new DateTime(1997, 5, 30),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Thanh",
                LastName = "Tran Chi",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 9, 18),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Manh",
                LastName = "Le Duc",
                Gender = "Male",
                DateOfBirth = new DateTime(2001, 4, 22),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
             new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Dung",
                LastName = "Dao Tan",
                Gender = "Male",
                DateOfBirth = new DateTime(2000, 12, 7),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            },
            new Person
            {
                Id = Guid.NewGuid(),
                FirstName = "Linh",
                LastName = "Nguyen",
                Gender = "Female",
                DateOfBirth = new DateTime(1999, 1, 27),
                PhoneNumber = "",
                BirthPlace = "Ha Noi",
                IsGraduated = false
            }
        };
        public List<Person> GetAll()
        {
            return _peopleList;
        }
        public Person? GetOne(Guid id)
        {
            return _peopleList.FirstOrDefault(o => o.Id == id);
        }
        public Person Add(Person person)
        {
            _peopleList.Add(person);
            return person;
        }
        public Person? Edit(Person person)
        {
            var entity = _peopleList.FirstOrDefault(d => d.Id == person.Id);
            if (entity == null) return null;

            entity.FirstName = person.FirstName;
            entity.LastName = person.LastName;
            entity.Gender = person.Gender;
            entity.DateOfBirth = person.DateOfBirth;
            entity.BirthPlace = person.BirthPlace;

            return entity;
        }
        public void Remove(Guid id)
        {
            var entity = _peopleList.FirstOrDefault(o => o.Id == id);
            if (entity != null)
            {
                _peopleList.Remove(entity);
            }
        }
        public bool Exits(Guid id)
        {
            return _peopleList.Any(d => d.Id == id);
        }
    }
}
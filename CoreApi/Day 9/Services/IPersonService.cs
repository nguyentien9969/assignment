using Person = Day_9.Models.Person;

namespace Day_9.Services
{
    public interface IPersonService
    {
        List<Person> GetAll();
        Person? GetOne(Guid id);
        Person Add(Person person);
        Person? Edit (Person person);
        void Remove(Guid id);
        bool Exits(Guid id);
        List<Person> FilterByGender(string Name);
        List<Person> FilterByFullName(string FullName);
        List<Person> FilterByBirthPlace(string BirthPlace);
    }
}
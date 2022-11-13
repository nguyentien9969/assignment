using Common.Enums;

namespace TestWebAPI.DTOS.Person
{
    public class PersonModel
    {
       public int Id { get; set; }
        public string Name { get; set; } 
        public Role Role { get; set; }
        public string UserName { get; set; }
    }
}

using Common.Enums;

namespace TestWebAPI.DTOS.Person
{
    public class LoginRespone
    {
        public int Id { get; set; }
        public string Username { get; set; }
        public string Name { get; set; } 
        public Role Role { get; set; }
        public string Token { get; set; }
    }
}

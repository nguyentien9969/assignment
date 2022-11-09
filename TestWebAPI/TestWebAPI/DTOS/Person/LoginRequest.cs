using Common.Enums;
using System.ComponentModel.DataAnnotations;

namespace TestWebAPI.DTOS.Person
{
    public class LoginRequest
    {
        [Required]
        public string Username { get; set; }
        [Required]
        public string Password { get; set; }   
    }
}

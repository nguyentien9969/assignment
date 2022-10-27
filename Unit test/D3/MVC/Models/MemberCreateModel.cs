using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class MemberCreateModel
    {
        [Required]
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public string? Gender { set; get; }
        public int? PhoneNumber { set; get; }
        public System.DateTime? DateOfBirth { set; get; }
        public string? BirthPlace { set; get; }
        public int? Id { set; get; }
    }
}
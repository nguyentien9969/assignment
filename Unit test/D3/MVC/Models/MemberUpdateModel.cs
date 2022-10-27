using System.ComponentModel.DataAnnotations;

namespace MVC.Models
{
    public class MemberUpdateModel
    {
        [Required]
        public string? FirstName { set; get; }
        public string? LastName { set; get; }
        public int? PhoneNumber { set; get; }
        public string? BirthPlace { set; get; }
        public int? Id { set; get; }
    }
}
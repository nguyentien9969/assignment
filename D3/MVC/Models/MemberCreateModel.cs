namespace MVC.Models
{
    public class MemberCreateModel
    {
        // [DisplayName("First Name")]
        // [Required(ErrorMessage = "{0} is Required")]
        public string? FirstName { set; get; }

        // [DisplayName("Last Name")]
        // [Required(ErrorMessage = "{0} is Required")]
        public string? LastName { set; get; }

        public string? Gender { set; get; }
        public int? PhoneNumber { set; get; }
        public System.DateTime? DateOfBirth { set; get; }
        public string? BirthPlace { set; get; }
        public int? Id { set; get; }
    }
}
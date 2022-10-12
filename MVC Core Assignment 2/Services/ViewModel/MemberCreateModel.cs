using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Services
{
    public class MemberCreateModel
    {
        [DisplayName("First Name")]
        [Required(ErrorMessage = "{0} is Required")]
        public string FirstName { set; get; }

        [DisplayName("Last Name")]
        [Required(ErrorMessage = "{0} is Required")]
        public string LastName { set; get; }

        public string Gender { set; get; }
        public int PhoneNumber { set; get; }
        public DateTime DateOfBirth { set; get; }
        public string BirthPlace { set; get; }
        public string Address { set; get; }
        public int Id { set; get; }
    }
}
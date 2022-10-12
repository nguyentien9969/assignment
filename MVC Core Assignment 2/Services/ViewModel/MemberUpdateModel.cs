using System.ComponentModel;
using System.ComponentModel.DataAnnotations;
namespace Services
{
    public class MemberUpdateModel
    {

        [Required, DisplayName("First Name")]
        public string FirstName { set; get; }

        [Required, DisplayName("First Name")]
        public string LastName { set; get; }

        public int PhoneNumber { set; get; }
        public string BirthPlace { set; get; }
        public int Id { set; get; }
    }
}
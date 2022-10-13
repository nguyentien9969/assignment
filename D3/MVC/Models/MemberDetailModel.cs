using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MVC.Models
{
    public class MemberDetailModel
    {
        public string? FirstName { set; get; }

        public string? LastName { set; get; }

        public string? Gender { set; get; }

        public int? PhoneNumber { set; get; }
        public string? BirthPlace { set; get; }
        public int? Id { set; get; }
    }
}
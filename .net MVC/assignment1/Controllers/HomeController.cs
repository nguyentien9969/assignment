using System.Diagnostics;
using assignment1.Models;

namespace assignment1.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    public HomeController(ILogger<HomeController> logger)
    {
        _logger = logger;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }

    [ResponseCache(Duration = 0, Location = ResponseCacheLocation.None, NoStore = true)]
    public IActionResult Error()
    {
        return View(new ErrorViewModel { RequestId = Activity.Current?.Id ?? HttpContext.TraceIdentifier });
    }
    public class Member
    {

        private string _firstName;
        private string _lastName;
        private string _gender;
        private DateTime _dateOfBirth;
        private int _phoneNumber;
        private string _birthPlace;
        private uint _age;
        private string _isGraduated;

        public string FirstName { get => _firstName; set => _firstName = value; }
        public string LastName { get => _lastName; set => _lastName = value; }
        public string Gender { get => _gender; set => _gender = value; }
        public int PhoneNumber { get => _phoneNumber; set => _phoneNumber = value; }
        public DateTime DateOfBirth { get => _dateOfBirth; set => _dateOfBirth = value; }
        public string BirthPlace { get => _birthPlace; set => _birthPlace = value; }
        public uint Age
        {
            get
            {
                uint today = (uint)DateTime.Today.Year;
                return today - (uint)DateOfBirth.Year;
            }
            set => _age = value;
        }

        public string IsGraduated { get => _isGraduated; set => _isGraduated = value; }

        public Member()
        {
        }

        public Member(string firstName, string lastName, string gender, DateTime dateOfBirth,
                        int phoneNumber, string birthPlace, string isGraduated)
        {
            FirstName = firstName;
            LastName = lastName;
            Gender = gender;
            DateOfBirth = dateOfBirth;
            PhoneNumber = phoneNumber;
            BirthPlace = birthPlace;
            IsGraduated = isGraduated;
        }

        public string Info
        {
            get => " ( " + FirstName + " , " + LastName + " , " + Gender + " , " + DateOfBirth +
             " , " + BirthPlace + " , " + PhoneNumber + " , " + Age + " , " + IsGraduated + " )";
        }

        public string FullName
        {
            get => FirstName + " " + LastName;
        }

        public uint GetAge()
        {
            uint today = (uint)DateTime.Today.Year;
            return today - (uint)DateOfBirth.Year;
        }

        public string GetIsGraduated(string isGraduated)
        {
            if (string.Equals(isGraduated, "true", StringComparison.OrdinalIgnoreCase))
            {
                return "ĐÃ TỐT NGHIỆP";
            }
            else
            {
                return "CHƯA TỐT NGHIỆP";
            }
        }

    }
}


using CsvHelper;
using Microsoft.AspNetCore.Mvc;
using MVC.Models;

namespace MVC.Controllers
{
    [Route("Nashtech/Rookie")]
    public class RookieController : Controller
    {
        private readonly static List<MemberModel> _member = new List<MemberModel>()
    {
         new MemberModel()
            {
                FirstName = "Vinh",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(2002, 3, 13),
                PhoneNumber = 0964083300,
                BirthPlace = "Ha Noi",
            },
            new MemberModel()
            {
                FirstName = "Duc",
                LastName = "Bui",
                Gender = "Female",
                DateOfBirth = new DateTime(2002, 9, 30),
                PhoneNumber = 0985483300,
                BirthPlace = "ha noi",
            },
            new MemberModel()
            {
                FirstName = "Ngai",
                LastName = "Nguyen",
                Gender = "Male",
                DateOfBirth = new DateTime(1999, 5, 30),
                PhoneNumber = 0875463300,
                BirthPlace = "Thai Binh",
            },
            new MemberModel()
            {
                FirstName = "Chuoi",
                LastName = "Le",
                Gender = "Female",
                DateOfBirth = new DateTime(2001, 4, 24),
                PhoneNumber = 0185683001,
                BirthPlace = "Quang Ngai",
            },
            new MemberModel()
            {
                FirstName = "Than",
                LastName = "Dang",
                Gender = "Female",
                DateOfBirth = new DateTime(2000, 10, 10),
                PhoneNumber = 0285483780,
                BirthPlace = "Thai Nguyen",
            }
    };

        private readonly ILogger<RookieController> _logger;

        public RookieController(ILogger<RookieController> logger)
        {
            _logger = logger;
        }

        #region #4

        [Route("all")]
        public IActionResult Index()
        {
            return Json(_member);
        }

        [Route("GetMaleMember")]
        public IActionResult GetMaleMember()
        {
            var data = _member.Where(x => x.Gender == "Male");
            return Json(data);
        }

        [Route("GetOldestMember")]
        public IActionResult GetOldestMember()
        {
            var maxAge = _member.Max(x => x.Age);
            var oldest = _member.FirstOrDefault(x => x.Age == maxAge);
            return Json(oldest);
        }

        [Route("GetFullName")]
        public IActionResult GetFullName()
        {
            var fullName = _member.Select(x => x.FullName);
            return Json(fullName);
        }

        [Route("GetMemberByBirthYear")]
        public IActionResult GetMemberByBirthYear(int year, string compareType)
        {
            switch (compareType)
            {
                case "equals":
                    return Json(_member.Where(p => p.DateOfBirth.Year == year));
                case "greaterThan":
                    return Json(_member.Where(p => p.DateOfBirth.Year > year));
                case "lessThan":
                    return Json(_member.Where(p => p.DateOfBirth.Year < year));
                default:
                    return Json(null);
            }
        }
        public IActionResult GetMembersWhoBorn2000()
        {
            return RedirectToAction("GetMemberByBirthYear", new { year = 2000, comparetype = "equal" });
        }
        public IActionResult GetMembersWhoBornBefore2000()
        {
            return RedirectToAction("GetMemberByBirthYear", new { year = 2000, comparetype = "greaterThan" });
        }
        public IActionResult GetMembersWhoBornAfter2000()
        {
            return RedirectToAction("GetMemberByBirthYear", new { year = 2000, comparetype = "lessThan" });
        }
        #endregion

        #region Export

        private byte[] WriteCsvToMemory(IEnumerable<MemberModel> member)
        {
            using (var memoryStream = new MemoryStream())
            using (var streamWriter = new StreamWriter(memoryStream))
            using (var csvWriter = new CsvWriter(streamWriter, System.Globalization.CultureInfo.CurrentCulture))
            {
                csvWriter.WriteRecords(member);
                streamWriter.Flush();
                return memoryStream.ToArray();
            }
        }

        [Route("Export")]
        public FileStreamResult Export()
        {
            var result = WriteCsvToMemory(_member);
            var memoryStream = new MemoryStream(result);
            return new FileStreamResult(memoryStream, "text/csv") { FileDownloadName = "export.csv" };
        }

        #endregion
    }
}
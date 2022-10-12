using assignment1.Models;
using Microsoft.AspNetCore.Mvc;
using System.Diagnostics;

namespace assignment1.Controllers
{
    public class RookieController : Controller
    {
        private readonly ILogger<RookieController> _logger;

        public RookieController(ILogger<RookieController> logger)
        {
            _logger = logger;
        }

    public static void Main(string[] args)
    {
        List<Member> memList = new List<Member>();
        memList.Add(new Member("Tien", "Nguyen", "male", new DateTime(2000, 10, 5), 0827844271, "BacGiang", "True"));
            memList.Add(new Member("Hung", "Pham", "male", new DateTime(1999, 10, 5), 0804085622, "NinhBinh", "false"));
            memList.Add(new Member("Hieu", "Luu", "male", new DateTime(1998, 10, 5), 0804060801, "CaMau", "false"));
            memList.Add(new Member("My", "Trinh", "female", new DateTime(2006, 10, 5), 0824040681, "Hanoi", "false"));
            memList.Add(new Member("Trung", "Luu", "male", new DateTime(2000, 10, 5), 0804743821, "Hanoi", "false"));
            memList.Add(new Member("Ha", "Nguyen", "female", new DateTime(1998, 10, 5), 0834467801, "Hue", "false"));
            memList.Add(new Member("Meo", "Con", "uknown", new DateTime(2020, 10, 5), 020, "a", "false"));
    }
    public IActionResult IsMaleList (Member member,List<Member> memList)
    {
         var data = from item in memList
                       where item.Gender == "male"
                       select item;

            foreach (var item in data)
            {
                Console.WriteLine(item.Info);
            }
        return View();
    }
    }

}
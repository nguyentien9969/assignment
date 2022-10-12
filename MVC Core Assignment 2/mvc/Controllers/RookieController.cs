using Microsoft.AspNetCore.Mvc;
using Services;


namespace mvc.Controllers;

public class RookieController : Controller
{

    private readonly ILogger<RookieController> _logger;

    private IMemberService _memberService;
    public RookieController(ILogger<RookieController> logger, IMemberService memberService)
    {
        _logger = logger;
        _memberService = memberService;
    }

    public IActionResult Index()
    {
        return View(_memberService.GetListMember());
    }

    [HttpGet]
    public IActionResult Create()
    {
        return View();
    }

    [HttpPost]
    public IActionResult Create(MemberCreateModel model)
    {
        if (ModelState.IsValid)
        {
            _memberService.AddMember(model);
            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        if (index >= 0 && index < _memberService.GetListMember().Count)
        {
            var member = _memberService.GetListMember()[index];
            var model = new MemberUpdateModel
            {
                FirstName = member.FirstName,
                LastName = member.LastName,
                PhoneNumber = member.PhoneNumber,
                BirthPlace = member.BirthPlace,
            };
            ViewData["Index"] = index;
            return View(model);
        }
        return View();
    }

    [HttpPost]
    public IActionResult Update(int index, MemberUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            if (index >= 0 && index < _memberService.GetListMember().Count)
            {
                var member = _memberService.GetListMember()[index];
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.PhoneNumber = model.PhoneNumber;
                member.BirthPlace = model.BirthPlace;

                _memberService.GetListMember()[index] = member;
            }
            Console.WriteLine("Index=" + index);

            return RedirectToAction("Index");
        }

        return View(model);
    }


}






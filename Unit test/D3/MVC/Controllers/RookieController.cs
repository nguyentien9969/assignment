using Microsoft.AspNetCore.Mvc;
using MVC.Service;
using MVC.Models;

namespace MVC.Controllers;

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
        var model = _memberService.GetAll();
        return View(model);
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
            var member = new MemberModel()
            {
                FirstName = model.FirstName,
                LastName = model.LastName,
                Gender = model.Gender,
                DateOfBirth = model.DateOfBirth,
                BirthPlace = model.BirthPlace,
                PhoneNumber = model.PhoneNumber
            };
            _memberService.Create(member);

            return RedirectToAction("Index");
        }
        return View(model);
    }

    [HttpGet]
    public IActionResult Edit(int index)
    {
        var member = _memberService.GetOne(index);
        if (member != null)
        {
            var model = new MemberUpdateModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                BirthPlace = member.BirthPlace,
                PhoneNumber = member.PhoneNumber,
            };
            ViewData["index"] = index;

            return View(model);
        }
        return BadRequest();
    }

    [HttpPost]
    public IActionResult Update(int index, MemberUpdateModel model)
    {
        if (ModelState.IsValid)
        {
            var member = _memberService.GetOne(index);
            if (member != null)
            {
                member.FirstName = model.FirstName;
                member.LastName = model.LastName;
                member.PhoneNumber = model.PhoneNumber;
                member.BirthPlace = model.BirthPlace;

                _memberService.Update(index, member);
            }
            return RedirectToAction("Index");
        }
        return BadRequest(ModelState);
    }

    public IActionResult Delete(int index)
    {
        var result = _memberService.Delete(index);
        if (result == null) return NotFound();

        return RedirectToAction("Index");
    }

    public IActionResult Detail(int index)
    {
        var member = _memberService.GetOne(index);
        if (member != null)
        {
            var model = new MemberDetailModel
            {
                Id = member.Id,
                FirstName = member.FirstName,
                LastName = member.LastName,
                BirthPlace = member.BirthPlace,
                PhoneNumber = member.PhoneNumber,
            };
            ViewData["index"] = index;

            return View(model);
        }
        return Content("NotFound");
    }

    [HttpPost]
    public IActionResult DeleteAndRedirectToResultView(int index)
    {
        var result = _memberService.Delete(index);
        if (result == null) return NotFound();

        HttpContext.Session.SetString("DeletedMemberName", result.FirstName);

        return RedirectToAction("DeleteResult");
    }

    public IActionResult DeleteResult()
    {
        return View();
    }
}







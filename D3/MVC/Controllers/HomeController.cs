using Microsoft.AspNetCore.Mvc;
using Microsoft.Extensions.Logging;
using MVC.Service;

namespace MVC.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;

    private IMemberService _memberService;
    public HomeController(ILogger<HomeController> logger,IMemberService memberService)
    {
        _logger = logger;
        _memberService = memberService;
    }

    public IActionResult Index()
    {
        return View();
    }

    public IActionResult Privacy()
    {
        return View();
    }
}

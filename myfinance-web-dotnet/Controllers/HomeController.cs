using System.Diagnostics;
using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Controllers;

public class HomeController : Controller
{
    private readonly ILogger<HomeController> _logger;
    private MyFinanceDbContext _myFinanceDbContext;

    public HomeController(ILogger<HomeController> logger, 
       MyFinanceDbContext MyFinanceDbContext)
    {
        _logger = logger;
       _myFinanceDbContext = MyFinanceDbContext;
    }

    public IActionResult Index()
    {
        var teste = _myFinanceDbContext.PlanoConta.FirstOrDefault();
        ViewBag.TESTE = teste.nome;
        
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
}

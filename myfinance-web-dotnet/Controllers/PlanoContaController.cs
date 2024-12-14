using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;


namespace myfinance_web_dotnet.Controllers;

[Route("[controller]")]
public class PlanoContaController : Controller
{
    private readonly IPlanoContaServices _planoContaServices;

    public PlanoContaController(IPlanoContaServices planoContaServices)
    {
        _planoContaServices = planoContaServices;
    }

    [Route("Index")]
    public IActionResult Index()
    {
        ViewBag.Lista = _planoContaServices.ListarRegistros();
        return View();
    }

    [HttpPost]
    [HttpGet]
    [Route("Cadastro")]
    [Route("Cadastro/{id}")]
    public IActionResult Cadastro(PlanoContaModel? model, int? id)
    {
        if (id != null)
        {
             var registro = _planoContaServices.RetornarRegistro((int)id);

             var planoContaModel = new PlanoContaModel()
             {
                 Id = registro.Id,
                 Nome = registro.Nome,
                 Tipo = registro.Tipo
             };
                 
             return View(planoContaModel);
         }
        else if (model != null && ModelState.IsValid)
        {
            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo
            };
            _planoContaServices.Salvar(planoConta);
            return RedirectToAction("Index");
        }
        else
        {
            return View();
        }
    }
    
    [HttpPost]
    public IActionResult Excluir(int id)
    {
        try
        {
            _planoContaServices.Excluir(id);
            TempData["SuccessMessage"] = "Plano conta excluída com sucesso!";
        }
        catch (Exception)
        {
            TempData["ErrorMessage"] = "Erro ao excluir a Plano Conta.";
        }

        return RedirectToAction("Index");
    }
}
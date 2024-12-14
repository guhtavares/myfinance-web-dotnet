using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Models;
using myfinance_web_dotnet.Services;

namespace myfinance_web_dotnet.Controllers;

public class TransacaoController : Controller
{
    private readonly ITransacaoService _transacaoService;
    private readonly IPlanoContaServices _planoContaServices;
    private readonly MyFinanceDbContext _myFinanceDbContext;
    
    public TransacaoController(ITransacaoService transacaoService,MyFinanceDbContext myFinanceDbContext)
    {
        _transacaoService = transacaoService;
        _myFinanceDbContext = myFinanceDbContext ?? throw new ArgumentNullException(nameof(myFinanceDbContext));
    }
    
    [Route("Index")]
    public IActionResult Index()
    {
        var transacoes = _myFinanceDbContext.Transacao; 
        
        var transacoesModel = transacoes.Select(t => new TransacaoModel
        {
            Id = t.Id,
            Data = t.Data,
            Valor = t.Valor,
            Historico = t.Historico,
            Tipo = t.Tipo,
            PlanoContaId = t.PlanoContaId
        }).ToList();
        
        ViewBag.ListaTransacao = transacoesModel;
        
        return View();
    }
    
    [HttpPost]
    [HttpGet]
    [Route("Transacao/Cadastro")]
    public IActionResult Cadastro(Transacao model)
    {
        if (model != null && ModelState.IsValid)
        {
            var transacao = new Transacao
            {
                Id = model.Id,
                Data = model.Data,
                Valor = model.Valor,
                Historico = model.Historico,
                Tipo = model.Tipo,
                PlanoContaId = model.PlanoContaId 
            };
            
            _transacaoService.Salvar(transacao);

            TempData["SuccessMessage"] = "Transação cadastrada com sucesso!";
            return RedirectToAction("Index"); 
        }
        return View();
    }
    
    
    [HttpPost]
    public IActionResult Excluir(int id)
    {
        try
        {
            _transacaoService.Excluir(id); 
            TempData["SuccessMessage"] = "Transação excluída com sucesso!";
        }
        catch (Exception)
        {
            TempData["ErrorMessage"] = "Erro ao excluir a transação.";
        }

        return RedirectToAction("Index"); 
    }
}
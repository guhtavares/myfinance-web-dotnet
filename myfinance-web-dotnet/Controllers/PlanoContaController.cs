﻿using Microsoft.AspNetCore.Mvc;
using myfinance_web_dotnet.Domain;
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
    public IActionResult Cadastro(PlanoContaModel? model)
    {
        if (model != null && ModelState.IsValid)
        {
            var planoConta = new PlanoConta
            {
                Id = model.Id,
                Nome = model.Nome,
                Tipo = model.Tipo
            };
            
            _planoContaServices.Salvar(planoConta);
        }
        return View();
    }
}
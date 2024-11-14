﻿using myfinance_web_dotnet.Domain;

namespace myfinance_web_dotnet.Services;

public interface IPlanoContaServices
{
    List<PlanoConta> ListarRegistros();
    
    void Salvar(PlanoConta item);
    
    void Excluir(int id);
    
    PlanoConta RetornarRegistro(int id);
    
}
using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services;

public interface IPlanoContaServices
{
    List<PlanoConta> ListarRegistros();
    
    void Salvar(PlanoConta item);
    
    void Excluir(int id);
    
    PlanoConta RetornarRegistro(int id);
    
}
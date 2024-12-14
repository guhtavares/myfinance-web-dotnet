using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;
using myfinance_web_dotnet.Models;

namespace myfinance_web_dotnet.Services;

public class PlanoContaServices : IPlanoContaServices
{
    private MyFinanceDbContext _myFinanceDbContext;

    public PlanoContaServices(MyFinanceDbContext myFinanceDbContext)
    {
        _myFinanceDbContext = myFinanceDbContext;
    }
    
    public List<PlanoConta> ListarRegistros()
    { 
        var lista = _myFinanceDbContext.PlanoConta.ToList();
        return lista;
    }

    public void Salvar(PlanoConta item)
    {
        var dbset = _myFinanceDbContext.PlanoConta;
        if (item.Id == null)
            dbset.Add(item);
        else
        {
            dbset.Attach(item);
            _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        _myFinanceDbContext.SaveChanges();
    }

    public void Excluir(int id)
    {
        var planoconta = _myFinanceDbContext.PlanoConta.FirstOrDefault(t => t.Id == id);
        
        if (planoconta != null)
        {
            _myFinanceDbContext.PlanoConta.Remove(planoconta);
            
            _myFinanceDbContext.SaveChanges();
        }
        else
        {
            throw new Exception("Plano conta não encontrada.");
        }
    }

    public PlanoConta RetornarRegistro(int id)
    {
        var item = _myFinanceDbContext.PlanoConta.Where(x => x.Id == id).First();
        
        return item;
    }
}
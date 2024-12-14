using myfinance_web_dotnet.Domain;
using myfinance_web_dotnet.Infrastructure;

namespace myfinance_web_dotnet.Services.Transacao;

public class TransacaoService : ITransacaoService
{   
    private MyFinanceDbContext _myFinanceDbContext;
    public TransacaoService(MyFinanceDbContext myFinanceDbContext)
    {
    
        _myFinanceDbContext = myFinanceDbContext;
    }
    
    public List<Domain.Transacao> ListarTransacoes()
    {
        var lista = _myFinanceDbContext.Transacao.ToList();
        return lista;
    }
    
    public void Salvar(Domain.Transacao item)
    {
        var dbset = _myFinanceDbContext.Transacao;
        if (item.Id == null)
        {
            dbset.Add(item);
        }
        else
        {
            dbset.Attach(item);
            _myFinanceDbContext.Entry(item).State = Microsoft.EntityFrameworkCore.EntityState.Modified;
        }
        
        _myFinanceDbContext.SaveChanges();
    }
    
    public void Excluir(int id)
    {
        var transacao = _myFinanceDbContext.Transacao.FirstOrDefault(t => t.Id == id);
        
        if (transacao != null)
        {
            _myFinanceDbContext.Transacao.Remove(transacao);
            
            _myFinanceDbContext.SaveChanges();
        }
        else
        {
            throw new Exception("Transação não encontrada.");
        }
    }
    
    
    public async Task<Domain.Transacao> RetornarRegistro(int id)
    {
        var item = _myFinanceDbContext.Transacao.Where(x => x.Id == id).First();
        
        return item;
    }
}
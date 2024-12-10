namespace myfinance_web_dotnet.Domain;

public interface ITransacaoService
{
    List<Transacao> ListarTransacoes();
    
    void Salvar(Transacao item);
    
    void  Excluir(int id);
    
    Task<Transacao> RetornarRegistro(int id);
}
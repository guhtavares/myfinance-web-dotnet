namespace myfinance_web_dotnet.Domain;

public class Transacao
{
    public int id { get; set; }
    public DateTime data { get; set; }
    public decimal valor { get; set; }
    public string Historico { get; set; }
    public string Tipo { get; set; }
    public int PlanoContaId { get; set; }
    public PlanoConta PlanoConta { get; set; }
}
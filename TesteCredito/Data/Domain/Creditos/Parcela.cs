namespace Domain.Creditos
{
    public class Parcela
    {
        public Guid IdFinanciamento { get; set; }
        public int NumeroParcela { get; set; }
        public double Valor { get; set; }
        public DateTime Vencimento { get; set; }
        public DateTime DataPagamento { get; set; }
    }
}

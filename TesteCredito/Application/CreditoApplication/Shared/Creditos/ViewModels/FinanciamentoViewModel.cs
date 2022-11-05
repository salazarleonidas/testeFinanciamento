using Domain.Enums;

namespace CreditoApplication.Shared.Creditos.ViewModels
{
    public class FinanciamentoViewModel
    {
        public double Valor { get; set; }
        public string Tipo { get; set; }
        public int QuantidadeParcelas { get; set; }
        public DateTime DataPrimeiraParcela { get; set; }
        public double? ValorJuros { get; set; }
        public string? Status { get; set; }
    }
}

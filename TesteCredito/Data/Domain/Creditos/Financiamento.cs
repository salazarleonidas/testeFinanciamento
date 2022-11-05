using Domain.Enums;

namespace Domain.Creditos
{
    public class Financiamento
    {
        public Guid Id { get; set; }
        public double Valor { get; set; }
        public TipoCredito Tipo { get; set; }
        public int QuantidadeParcelas { get; set; }

        public List<Parcela> Parcelas { get; set; }
    }
}

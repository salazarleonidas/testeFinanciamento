using CreditoApplication.Shared.Creditos.Repository;
using Domain.Enums;

namespace DataServices.Creditos.Repository
{
    public class TaxaJurosRepository : ITaxaJurosRepository
    {
        private readonly Dictionary<TipoCredito, double> _taxas = new()
        {
            {TipoCredito.Direto, 0.02 },
            {TipoCredito.PessoaJuridica, 0.05 },
            {TipoCredito.PessoaFisica, 0.03 },
            {TipoCredito.Imobiliario, 0.09 },
            {TipoCredito.Consignado, 0.01 },
        };

        public double GetByTipo(TipoCredito tipo)
        {
            return _taxas[tipo];
        }
    }
}

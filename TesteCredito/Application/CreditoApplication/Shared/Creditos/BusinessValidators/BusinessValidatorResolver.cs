using Domain.Creditos;
using Domain.Enums;

namespace CreditoApplication.Shared.Creditos.BusinessValidators
{
    public static class BusinessValidatorResolver
    {
        public static IFinancimantoValidator Resolve(Financiamento financiamento)
        {
            switch (financiamento.Tipo)
            {
                case TipoCredito.PessoaJuridica:
                    return new FinanciamentoPessoaJuridicaValidator(financiamento);
                case TipoCredito.Direto:
                case TipoCredito.Consignado:
                case TipoCredito.PessoaFisica:
                case TipoCredito.Imobiliario:
                default:
                    return new BaseFinanciamentoValidator(financiamento);
            }
        }
    }
}

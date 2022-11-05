using Domain.Creditos;

namespace CreditoApplication.Shared.Creditos.BusinessValidators
{
    public class BaseFinanciamentoValidator : IFinancimantoValidator
    {
        protected string _errors;

        protected readonly Financiamento _financiamento;
        protected List<Func<string?>> _validations;

        public BaseFinanciamentoValidator(Financiamento financiamento)
        {
            _errors = string.Empty;
            _financiamento = financiamento;
            _validations = new List<Func<string?>>();
        }

        public string GetError() => _errors;

        public bool Validate()
        {
            _validations = new List<Func<string?>>
            {
                ValidarValor,
                ValidarDataPrimeiroPagamento,
                ValidarQuantidadeParcelas
            };

            return Execute();
        }

        private bool Execute()
        {
            foreach (var func in _validations)
            {
                var result = func();
                if (!string.IsNullOrEmpty(result))
                {
                    _errors = result;
                    return false;
                }
            }

            return true;
        }

        protected virtual string? ValidarValor()
        {
            return _financiamento.Valor > 1000000 ? "Valor não deve ser maior que R$1.000.000,00" : null;
        }

        protected virtual string? ValidarDataPrimeiroPagamento()
        {
            var dataMinima = DateTime.Today.AddDays(15);
            var dataMaxima = DateTime.Today.AddDays(40);

            var dataPrimeiraParcela = _financiamento.Parcelas.Min(q => q.Vencimento);

            return dataPrimeiraParcela < dataMinima || dataPrimeiraParcela > dataMaxima ?
                    "A data da primeira parcela precisa ser entre 15 e 40 dias a partir da data de hoje." :
                    null;
        }

        protected virtual string? ValidarQuantidadeParcelas()
        {
            return _financiamento.QuantidadeParcelas < 5 || _financiamento.QuantidadeParcelas > 72 ?
                "A quantidade de parcelas deve ser entre 5 e 72" : null;
        }
    }
}

using Domain.Creditos;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditoApplication.Shared.Creditos.BusinessValidators
{
    public sealed class FinanciamentoPessoaJuridicaValidator : BaseFinanciamentoValidator
    {
        public FinanciamentoPessoaJuridicaValidator(Financiamento financiamento) : base(financiamento) { }

        protected override string? ValidarValor()
        {
            return _financiamento.Valor > 1000000 || _financiamento.Valor < 15000 ?
                "Valor não deve ser maior que R$1.000.000,00 ou menor que R$15.000,00" : null;
        }
    }
}

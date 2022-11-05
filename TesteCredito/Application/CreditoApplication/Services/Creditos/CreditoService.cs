using AutoMapper;
using CreditoApplication.Services.Interfaces;
using CreditoApplication.Shared.Creditos.BusinessValidators;
using CreditoApplication.Shared.Creditos.Repository;
using CreditoApplication.Shared.Creditos.ViewModels;
using CreditoApplication.Shared.Exceptions;
using CreditoApplication.Shared.Helper;
using Domain.Creditos;
using Domain.Enums;

namespace CreditoApplication.Services.Creditos
{
    public class CreditoService : ICreditoService
    {
        private readonly IMapper _mapper;
        private readonly ITaxaJurosRepository _taxaJurosRepository;
        public CreditoService(IMapper mapper, ITaxaJurosRepository taxaJurosRepository)
        {
            _mapper = mapper;
            _taxaJurosRepository = taxaJurosRepository;
        }

        public FinanciamentoViewModel RequisitarFiancimento(FinanciamentoViewModel financiamentoViewModel)
        {
            var financiamento = _mapper.Map<Financiamento>(financiamentoViewModel);

            CriarParcelas(financiamento, financiamentoViewModel.DataPrimeiraParcela);

            var validator = BusinessValidatorResolver.Resolve(financiamento);
            if (!validator.Validate())
                throw new ValidationErrorException(validator.GetError());

            return CalculoJuros(financiamento);
        }

        private FinanciamentoViewModel CalculoJuros(Financiamento financiamento)
        {
            var valorInicial = financiamento.Valor;
            var taxa = _taxaJurosRepository.GetByTipo(financiamento.Tipo);
            var tempoAplicacao = financiamento.QuantidadeParcelas;

            var montante = valorInicial * Math.Pow(1 + taxa, tempoAplicacao);
            var juros = montante - valorInicial;

            var dataPrimeiraParcela = financiamento.Parcelas.Min(q => q.Vencimento);

            var financiamentoViewModel = new FinanciamentoViewModel
            {
                DataPrimeiraParcela = dataPrimeiraParcela,
                QuantidadeParcelas = financiamento.Parcelas.Count,
                Status = StatusFinanciamento.Aprovado.GetDescription(),
                Valor = montante,
                Tipo = financiamento.Tipo.GetDescription(),
                ValorJuros = juros
            };

            return financiamentoViewModel;
        }

        private void CriarParcelas(Financiamento financiamento, DateTime primeiroVencimento)
        {
            financiamento.Parcelas = new List<Parcela>();
            var valorParcela = financiamento.Valor/financiamento.QuantidadeParcelas;
            for(var i = 0; i < financiamento.QuantidadeParcelas; ++i){
                var parcela = new Parcela{
                    NumeroParcela = i + 1,
                    Valor = valorParcela,
                    Vencimento = primeiroVencimento.AddMonths(i)
                };
                financiamento.Parcelas.Add(parcela);
            }

        }
    }
}

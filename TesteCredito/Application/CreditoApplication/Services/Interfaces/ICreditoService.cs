using CreditoApplication.Shared.Creditos.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CreditoApplication.Services.Interfaces
{
    public interface ICreditoService
    {
        FinanciamentoViewModel RequisitarFiancimento(FinanciamentoViewModel financiamento);
    }
}

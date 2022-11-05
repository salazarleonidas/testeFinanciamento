using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Enums
{
    public enum TipoCredito
    {
        [Description("Direto")]
        Direto,
        [Description("Consignado")]
        Consignado,
        [Description("Pessoa Física")]
        PessoaFisica,
        [Description("Pessoa Jurídica")]
        PessoaJuridica,
        [Description("Imobiliário")]
        Imobiliario
    }
}

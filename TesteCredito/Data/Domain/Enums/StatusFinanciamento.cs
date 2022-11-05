using System.ComponentModel;

namespace Domain.Enums
{
    public enum StatusFinanciamento
    {
        [Description("Aprovado")]
        Aprovado,
        [Description("Reprovado")]
        Reprovado,
        [Description("Em análise")]
        EmAnalise
    }
}

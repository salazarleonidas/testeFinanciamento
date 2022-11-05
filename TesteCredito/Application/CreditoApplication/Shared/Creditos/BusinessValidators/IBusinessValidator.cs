using Domain.Creditos;

namespace CreditoApplication.Shared.Creditos.BusinessValidators
{
    public interface IFinancimantoValidator
    {
        bool Validate();
        string GetError();
    }
}

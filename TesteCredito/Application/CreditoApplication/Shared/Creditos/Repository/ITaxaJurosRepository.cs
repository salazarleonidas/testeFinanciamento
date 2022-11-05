using Domain.Enums;

namespace CreditoApplication.Shared.Creditos.Repository
{
    public interface ITaxaJurosRepository
    {
        double GetByTipo(TipoCredito tipo);
    }
}

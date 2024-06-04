using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ISistemaFinanceiro
{
    public interface ISistemaFinanceiro : IGeneric<SistemaFinanceiro>
    {
        Task<IList<SistemaFinanceiro>> ListarSistemaFinanceiroUsuario(string emailUsuario);
    }
}

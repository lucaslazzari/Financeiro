using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.ICategoria
{
    public interface ICategoria : IGeneric<Categoria>
    {
        Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario);
    }
}

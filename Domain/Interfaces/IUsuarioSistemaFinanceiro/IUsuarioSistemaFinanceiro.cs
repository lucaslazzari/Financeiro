using Domain.Interfaces.Generics;
using Entities.Entities;

namespace Domain.Interfaces.IUsuarioSistemaFinanceiro
{
    public interface IUsuarioSistemaFinanceiro : IGeneric<UsuarioSistemaFinanceiro>
    {
        Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int idSistema);
        Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios);
        Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario);
    }
}

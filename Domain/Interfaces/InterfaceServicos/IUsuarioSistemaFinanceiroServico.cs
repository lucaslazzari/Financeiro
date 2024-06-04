using Entities.Entities;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface IUsuarioSistemaFinanceiroServico
    {
        Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro);
    }
}

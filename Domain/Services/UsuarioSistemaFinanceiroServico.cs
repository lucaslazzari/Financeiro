using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;

namespace Domain.Services
{
    public class UsuarioSistemaFinanceiroServico : IUsuarioSistemaFinanceiroServico
    {
        private readonly IUsuarioSistemaFinanceiro _interfaceUsuarioSistemaFinanceiro;
        public UsuarioSistemaFinanceiroServico(IUsuarioSistemaFinanceiro interfaceUsuarioSistemaFinanceiro)
        {
            _interfaceUsuarioSistemaFinanceiro = interfaceUsuarioSistemaFinanceiro;
        }
        public async Task CadastrarUsuarioNoSistema(UsuarioSistemaFinanceiro usuarioSistemaFinanceiro)
        {
            await _interfaceUsuarioSistemaFinanceiro.Add(usuarioSistemaFinanceiro);
        }
    }
}

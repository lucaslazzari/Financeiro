using Entities.Entities;

namespace Domain.Interfaces.InterfaceServicos
{
    public interface ISistemaFinanceiroServico
    {
        Task AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
        Task AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro);
    }
}

using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;
using Entities.Enums;

namespace Domain.Services
{
    public class DespesaServico : IDespesaServico
    {
        private readonly IDespesa _interfaceDespesa;
        public DespesaServico(IDespesa interfaceDespesa)
        {
            _interfaceDespesa = interfaceDespesa;
        }

        public async Task AdicionarDespesa(Despesa despesa)
        {
            // Validação data
            var data = DateTime.UtcNow;
            despesa.DataCadastro = data;
            despesa.Ano = data.Year;
            despesa.Mes = data.Month;

            // Validação nome
            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Add(despesa);
        }

        public async Task AtualizarDespesa(Despesa despesa)
        {
            var data = DateTime.UtcNow;
            despesa.DataAlteracao = data;

            if (despesa.Pago)
            {
                despesa.DataPagamento = data;
            }

            var valido = despesa.ValidarPropriedadeString(despesa.Nome, "Nome");
            if (valido)
                await _interfaceDespesa.Update(despesa);
        }

        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            var despesasUsuario = await _interfaceDespesa.ListarDespesasUsuario(emailUsuario);
            var despesasAnterior = await _interfaceDespesa.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUsuario);

            var despesasNaoPagasMesesAnteriores = despesasAnterior.Any() ?
                despesasAnterior.ToList().Sum(x => x.Valor) : 0;

            var despesasPagas = despesasUsuario.Where(d => d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var despesasPendentes = despesasUsuario.Where(d => !d.Pago && d.TipoDespesa == EnumTipoDespesa.Contas)
                .Sum(x => x.Valor);

            var investimentos = despesasUsuario.Where(d => d.TipoDespesa == EnumTipoDespesa.Investimento)
                .Sum(x => x.Valor);

            return new
            {
                sucesso = "OK",
                despesasPagas = despesasPagas,
                despesasPendentes = despesasPendentes,
                despesasNaoPagasMesesAnteriores = despesasNaoPagasMesesAnteriores,
                investimentos = investimentos
            };
        }
    }
}

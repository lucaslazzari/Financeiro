using Domain.Interfaces.IDespesa;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class DespesaController : ControllerBase
    {
        private readonly IDespesa _despesa;
        private readonly IDespesaServico _despesaServico;
        public DespesaController(IDespesa despesa, IDespesaServico despesaServico)
        {
            _despesa = despesa;
            _despesaServico = despesaServico;
        }


        [HttpGet("/api/ListarDespesasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuario(string emailUsuario)
        {
            return await _despesa.ListarDespesasUsuario(emailUsuario);
        }


        [HttpGet("/api/ListarDespesasUsuarioNaoPagasMesesAnterior")]
        [Produces("application/json")]
        public async Task<object> ListarDespesasUsuarioNaoPagasMesesAnterior(string emailUsuario)
        {
            return await _despesa.ListarDespesasUsuarioNaoPagasMesesAnterior(emailUsuario);
        }


        [HttpPost("/api/AdicionarDespesa")]
        [Produces("application/json")]
        public async Task<object> AdicionarDespesa(Despesa despesa)
        {
            await _despesaServico.AdicionarDespesa(despesa);

            return despesa;
        }


        [HttpPut("/api/AtualizarDespesa")]
        [Produces("application/json")]
        public async Task<object> AtualizarDespesa(Despesa despesa)
        {
            await _despesaServico.AtualizarDespesa(despesa);

            return despesa;
        }


        [HttpGet("/api/ObterDespesa")]
        [Produces("application/json")]
        public async Task<object> ObterDespesa(int id)
        {
            return await _despesa.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteDespesa")]
        [Produces("application/json")]
        public async Task<object> DeleteDespesa(int id)
        {
            try
            {
                var despesa = await _despesa.GetEntityById(id);

                await _despesa.Delete(despesa);
            }catch(Exception)
            {
                return false;
            }
            return true;
        }


        [HttpGet("/api/CarregaGraficos")]
        [Produces("application/json")]
        public async Task<object> CarregaGraficos(string emailUsuario)
        {
            return await _despesaServico.CarregaGraficos(emailUsuario);
        }
    }
}

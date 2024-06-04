using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class SistemaFinanceiroController : ControllerBase
    {
        private readonly ISistemaFinanceiro _sistemaFinanceiro;
        private readonly ISistemaFinanceiroServico _sistemaFinanceiroServico;
        public SistemaFinanceiroController(ISistemaFinanceiro sistemaFinanceiro, ISistemaFinanceiroServico sistemaFinanceiroServico)
        {
            _sistemaFinanceiro = sistemaFinanceiro;
            _sistemaFinanceiroServico = sistemaFinanceiroServico;
        }


        [HttpGet("/api/ListaSistemasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListaSistemasUsuario(string emailUsuario)
        {
            return await _sistemaFinanceiro.ListarSistemaFinanceiroUsuario(emailUsuario);
        }


        [HttpPost("/api/AdicionarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AdicionarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
                {
            await _sistemaFinanceiroServico.AdicionarSistemaFinanceiro(sistemaFinanceiro);

            return sistemaFinanceiro;
        }


        [HttpPut("/api/AtualizarSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> AtualizarSistemaFinanceiro(SistemaFinanceiro sistemaFinanceiro)
        {
            await _sistemaFinanceiroServico.AtualizarSistemaFinanceiro(sistemaFinanceiro);

            return Task.FromResult(sistemaFinanceiro);
        }


        [HttpGet("/api/ObterSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> ObterSistemaFinanceiro(int id)
        {
            return await _sistemaFinanceiro.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteSistemaFinanceiro(int id)
        {
            try
            {
                var sistemaFinanceiro = await _sistemaFinanceiro.GetEntityById(id);

                await _sistemaFinanceiro.Delete(sistemaFinanceiro);
            }catch(Exception)
            {
                return false;
            }
            return true;         
        }

    }
}

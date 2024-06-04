using Domain.Interfaces.InterfaceServicos;
using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class UsuarioSistemaFinanceiroController : ControllerBase
    {
        private readonly IUsuarioSistemaFinanceiro _usuarioSistemaFinanceiro;
        private readonly IUsuarioSistemaFinanceiroServico _usuarioSistemaFinanceiroServico;
        public UsuarioSistemaFinanceiroController(IUsuarioSistemaFinanceiro usuarioSistemaFinanceiro, IUsuarioSistemaFinanceiroServico usuarioSistemaFinanceiroServico)
        {
            _usuarioSistemaFinanceiro = usuarioSistemaFinanceiro;
            _usuarioSistemaFinanceiroServico = usuarioSistemaFinanceiroServico;
        }


        [HttpGet("/api/ListarUsuariosSistema")]
        [Produces("application/json")]
        public async Task<object> ListarUsuariosSistema(int idSistema)
        {
            return await _usuarioSistemaFinanceiro.ListarUsuariosSistema(idSistema);
        }


        [HttpPost("/api/CadastrarUsuarioNoSistema")]
        [Produces("application/json")]
        public async Task<object> CadastrarUsuarioNoSistema(int idSistema, string emailUsuario)
        {
            try
            {
                await _usuarioSistemaFinanceiroServico.CadastrarUsuarioNoSistema(
                    new UsuarioSistemaFinanceiro
                    {
                        IdSistema = idSistema,
                        EmailUsuario = emailUsuario,   
                        Administrador = false,
                        SistemaAtual = true
                    });
            }catch(Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }


        [HttpDelete("/api/DeleteUsuarioSistemaFinanceiro")]
        [Produces("application/json")]
        public async Task<object> DeleteUsuarioSistemaFinanceiro(int id)
        {
            try
            {
                var usuarioSistemaFinanceiro = await _usuarioSistemaFinanceiro.GetEntityById(id);
                await _usuarioSistemaFinanceiro.Delete(usuarioSistemaFinanceiro);
            }
            catch (Exception)
            {
                return Task.FromResult(false);
            }
            return Task.FromResult(true);
        }
    }
}

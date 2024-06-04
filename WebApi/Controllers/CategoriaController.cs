using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;

namespace WebApi.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    [Authorize]
    public class CategoriaController : ControllerBase
    {
        private readonly ICategoria _categoria;
        private readonly ICategoriaServico _categoriaServico;
        public CategoriaController(ICategoria categoria, ICategoriaServico categoriaServico)
        {
            _categoria = categoria;
            _categoriaServico = categoriaServico;
        }


        [HttpGet("/api/ListarCategoriasUsuario")]
        [Produces("application/json")]
        public async Task<object> ListarCategoriasUsuario(string emailUsuario)
        {
            return await _categoria.ListarCategoriasUsuario(emailUsuario);
        }


        [HttpPost("/api/AdicionarCategoria")]
        [Produces("application/json")]
        public async Task<object> AdicionarCategoria(Categoria categoria)
        {
            await _categoriaServico.AdicionarCategoria(categoria);

            return categoria;
        }


        [HttpPut("/api/AtualizarCategoria")]
        [Produces("application/json")]
        public async Task<object> AtualizarCategoria(Categoria categoria)
        {
            await _categoriaServico.AtualizarCategoria(categoria);

            return categoria;
        }


        [HttpGet("/api/ObterCategoria")]
        [Produces("application/json")]
        public async Task<object> ObterCategoria(int id)
        {
            return await _categoria.GetEntityById(id);
        }


        [HttpDelete("/api/DeleteCategoria")]
        [Produces("application/json")]
        public async Task<object> DeleteCategoria(int id)
        {
            try
            {
                var categoria = await _categoria.GetEntityById(id);

                await _categoria.Delete(categoria);
            }catch (Exception)
            {
                return false;
            }
            return true;
        }
    }
}

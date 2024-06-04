using Domain.Interfaces.ICategoria;
using Domain.Interfaces.InterfaceServicos;
using Entities.Entities;

namespace Domain.Services
{
    public class CategoriaServico : ICategoriaServico
    {
        private readonly ICategoria _interfaceCategoria;
        public CategoriaServico(ICategoria interfaceCategoria)
        {
            _interfaceCategoria = interfaceCategoria;
        }
        public async Task AdicionarCategoria(Categoria categoria)
        {
            // Validação nome
            var valido = categoria.ValidarPropriedadeString(categoria.Nome,"Nome");
            if (valido)
                await _interfaceCategoria.Add(categoria);
        }

        public async Task AtualizarCategoria(Categoria categoria)
        {
            // Validação nome
            var valido = categoria.ValidarPropriedadeString(categoria.Nome, "Nome");
            if(valido)
                await _interfaceCategoria.Update(categoria);
        }
    }
}

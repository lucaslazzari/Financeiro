using Domain.Interfaces.ICategoria;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class CategoriaRepository : GenericsRepository<Categoria>, ICategoria
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public CategoriaRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<Categoria>> ListarCategoriasUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join c in banco.Categoria on s.Id equals c.IdSistema
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario) && us.SistemaAtual
                     select c).AsNoTracking().ToListAsync();
            }
        }
    }
}

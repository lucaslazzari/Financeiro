using Domain.Interfaces.IUsuarioSistemaFinanceiro;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class UsuarioSistemaFinanceiroRepository : GenericsRepository<UsuarioSistemaFinanceiro>, IUsuarioSistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public UsuarioSistemaFinanceiroRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<UsuarioSistemaFinanceiro>> ListarUsuariosSistema(int idSistema)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiro
                    .Where(s=>s.IdSistema == idSistema).AsNoTracking()
                    .ToListAsync();
            }
        }

        public async Task<UsuarioSistemaFinanceiro> ObterUsuarioPorEmail(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    banco.UsuarioSistemaFinanceiro
                    .AsNoTracking().FirstOrDefaultAsync(x => x.EmailUsuario.Equals(emailUsuario));
            }
        }

        public async Task RemoveUsuarios(List<UsuarioSistemaFinanceiro> usuarios)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                banco.UsuarioSistemaFinanceiro
                .RemoveRange(usuarios);

                await banco.SaveChangesAsync();
            }
        }
    }
}

using Domain.Interfaces.ISistemaFinanceiro;
using Entities.Entities;
using Infra.Configuration;
using Infra.Repositories.Generics;
using Microsoft.EntityFrameworkCore;

namespace Infra.Repositories
{
    public class SistemaFinanceiroRepository : GenericsRepository<SistemaFinanceiro>, ISistemaFinanceiro
    {
        private readonly DbContextOptions<ContextBase> _optionsBuilder;
        public SistemaFinanceiroRepository()
        {
            _optionsBuilder = new DbContextOptions<ContextBase>();
        }
        public async Task<IList<SistemaFinanceiro>> ListarSistemaFinanceiroUsuario(string emailUsuario)
        {
            using (var banco = new ContextBase(_optionsBuilder))
            {
                return await
                    (from s in banco.SistemaFinanceiro
                     join us in banco.UsuarioSistemaFinanceiro on s.Id equals us.IdSistema
                     where us.EmailUsuario.Equals(emailUsuario)
                     select s).AsNoTracking().ToListAsync();
            }
        }
    }
}

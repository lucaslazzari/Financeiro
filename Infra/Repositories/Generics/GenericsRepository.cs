using Azure.Core;
using Domain.Interfaces.Generics;
using Infra.Configuration;
using Microsoft.EntityFrameworkCore;
using Microsoft.Win32.SafeHandles;
using System.Runtime.InteropServices;

namespace Infra.Repositories.Generics
{
    public class GenericsRepository<T> : IGeneric<T> where T : class
    {
        private readonly DbContextOptions<ContextBase> _OptionsBuilder;
        public GenericsRepository()
        {
            _OptionsBuilder = new DbContextOptions<ContextBase>();
        }

        public async Task Add(T Objeto)
        {
            using(var data = new ContextBase(_OptionsBuilder))
            {
                await data.Set<T>().AddAsync(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task Delete(T Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Remove(Objeto);
                await data.SaveChangesAsync();
            }
        }

        public async Task<T> GetEntityById(int id)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().FindAsync(id);
            }
        }

        public async Task<List<T>> List()
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                return await data.Set<T>().ToListAsync();
            }
        }

        public async Task Update(T Objeto)
        {
            using (var data = new ContextBase(_OptionsBuilder))
            {
                data.Set<T>().Update(Objeto);
                await data.SaveChangesAsync();
            }
        }

        #region Disposed https://learn.microsoft.com/pt-br/dotnet/standard/garbage-collection/implementing-dispose

        bool disposed = false;

        SafeHandle handle = new SafeFileHandle(IntPtr.Zero, true);

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }

        protected virtual void Dispose(bool disposing)
        {
            if (disposed) return;

            if(disposing)
            {
                handle.Dispose();
            }

            disposed = true;
        }
        #endregion
    }
}

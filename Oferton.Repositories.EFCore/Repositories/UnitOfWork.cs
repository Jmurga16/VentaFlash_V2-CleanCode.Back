using Oferton.Entities.Interfaces;
using Oferton.Repositories.EFCore.DataContext;
using System.Threading.Tasks;

namespace Oferton.Repositories.EFCore.Repositories
{
    public class UnitOfWork : IUnitOfWork
    {
        readonly OfertonContext Context;
        public UnitOfWork(OfertonContext context) => Context = context;

        public Task<int> SaveChangesAsync()
        {
            return Context.SaveChangesAsync();
        }
    }
}

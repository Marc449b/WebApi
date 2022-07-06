using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base.Entity;
using WebApi.DataAccess.Repository.Base.Interface;

namespace WebApi.DataAccess.Repository.Base
{
    public abstract class RepositoryBase<TModel, TContext> : IRepositoryBase<TModel>
        where TModel : BaseEntity
        where TContext : DbContext, new()
    {
        protected TContext context;

        public RepositoryBase(TContext context)
        {
            this.context = context;
        }


        public virtual async Task AddAsync(TModel model, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(model, cancellationToken);
        }

        public virtual async Task<TModel?> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TModel>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        public virtual void Remove(TModel model)
        {
            context.Remove(model);
        }

        public virtual async Task<bool> ExistsAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TModel>().Where(x => x.Id == id).Select(x => x.Id).AnyAsync(cancellationToken);
        }
    }
}
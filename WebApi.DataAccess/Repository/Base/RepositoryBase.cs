using Mapster;
using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.Models.Base.Entity;
using WebApi.DataAccess.Repository.Base.Interface;

namespace WebApi.DataAccess.Repository.Base
{
    public abstract class RepositoryBase<TModel, TDto, TContext> : IRepositoryBase<TModel, TDto>
        where TModel : BaseEntity
        where TDto : BaseEntity
        where TContext : DbContext, new()
    {
        protected TContext context;

        public RepositoryBase(TContext context)
        {
            this.context = context;
        }


        // Create
        public virtual async Task AddAsync(TModel model, CancellationToken cancellationToken = default)
        {
            await context.AddAsync(model, cancellationToken);
        }

        // Read
        public virtual async Task<TDto> GetByIdAsync(Guid id, CancellationToken cancellationToken = default)
        {
            return await context.Set<TModel>().ProjectToType<TDto>().FirstOrDefaultAsync(x => x.Id == id, cancellationToken);
        }

        // Update
        public virtual void Update(TModel model)
        {
            context.Set<TModel>().Update(model);
        }

        // Delete
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
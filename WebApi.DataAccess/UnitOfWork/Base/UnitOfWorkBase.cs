using Microsoft.EntityFrameworkCore;
using WebApi.DataAccess.UnitOfWork.Base.Interface;

namespace WebApi.DataAccess.UnitOfWork.Base
{
    public abstract class UnitOfWorkBase<TContext> : IUnitOfWorkBase
        where TContext : DbContext, new()
    {
        protected readonly TContext context;

        public UnitOfWorkBase(TContext context)
        {
            this.context = context;
        }


        public virtual async Task SaveChangesAsync(CancellationToken cancellationToken = default)
        {
            await context.SaveChangesAsync(cancellationToken);
        }


        #region Dispose
        private bool disposed = false;

        protected virtual void Dispose(bool disposing)
        {
            if (!disposed)
            {
                if (disposing)
                {
                    context.Dispose();
                }
            }
            disposed = true;
        }

        public void Dispose()
        {
            Dispose(true);
            GC.SuppressFinalize(this);
        }
        #endregion
    }
}
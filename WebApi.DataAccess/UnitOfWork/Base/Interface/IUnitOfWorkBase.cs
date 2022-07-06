namespace WebApi.DataAccess.UnitOfWork.Base.Interface
{
    /// <summary>
    /// Base unit of work for easy and fast development of different unit of work.
    /// </summary>
    public interface IUnitOfWorkBase : IDisposable
    {
        Task SaveChangesAsync();
    }
}
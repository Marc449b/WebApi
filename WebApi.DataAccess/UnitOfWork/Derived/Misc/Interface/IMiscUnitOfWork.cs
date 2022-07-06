using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using WebApi.DataAccess.UnitOfWork.Base.Interface;

namespace WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface
{
    public interface IMiscUnitOfWork : IUnitOfWorkBase
    {
        IJsonEntityRepository JsonEntityRepository { get; }
    }
}
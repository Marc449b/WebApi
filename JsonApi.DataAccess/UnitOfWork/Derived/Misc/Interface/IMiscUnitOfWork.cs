using JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using JsonApi.DataAccess.UnitOfWork.Base.Interface;

namespace JsonApi.DataAccess.UnitOfWork.Derived.Misc.Interface
{
    public interface IMiscUnitOfWork : IUnitOfWorkBase
    {
        IJsonEntityRepository JsonEntityRepository { get; }
    }
}
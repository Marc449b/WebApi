using WebApi.DataAccess.Models.Derived.Misc;
using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity;
using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using WebApi.DataAccess.UnitOfWork.Base;
using WebApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

namespace WebApi.DataAccess.UnitOfWork.Derived.Misc
{
    public class MiscUnitOfWork : UnitOfWorkBase<MiscContext>, IMiscUnitOfWork
    {
        public MiscUnitOfWork(MiscContext context) : base(context) { }


        public IJsonEntityRepository JsonEntityRepository => JsonEntityRepository ?? new JsonEntityRepository(context);
    }
}
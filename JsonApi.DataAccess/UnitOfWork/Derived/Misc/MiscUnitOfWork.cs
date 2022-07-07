using JsonApi.DataAccess.Models.Derived.Misc;
using JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity;
using JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using JsonApi.DataAccess.UnitOfWork.Base;
using JsonApi.DataAccess.UnitOfWork.Derived.Misc.Interface;

namespace JsonApi.DataAccess.UnitOfWork.Derived.Misc
{
    public class MiscUnitOfWork : UnitOfWorkBase<MiscContext>, IMiscUnitOfWork
    {
        private JsonEntityRepository jsonEntityRepository;

        public MiscUnitOfWork(MiscContext context) : base(context) { }


        public IJsonEntityRepository JsonEntityRepository { get => jsonEntityRepository ??= new (context); }
}
}
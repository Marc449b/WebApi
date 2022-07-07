using WebApi.DataAccess.Repository.Base.Interface;
using Model = WebApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;


namespace WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface
{
    public interface IJsonEntityRepository : IRepositoryBase<Model> { }
}
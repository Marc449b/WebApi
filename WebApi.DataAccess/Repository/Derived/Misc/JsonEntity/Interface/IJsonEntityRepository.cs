using WebApi.DataAccess.Repository.Base.Interface;
using Model = WebApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;
using ModelDto = WebApi.DataAccess.Dto.Derived.Misc.JsonEntity.JsonEntityDto;

namespace WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface
{
    public interface IJsonEntityRepository : IRepositoryBase<Model, ModelDto> { }
}
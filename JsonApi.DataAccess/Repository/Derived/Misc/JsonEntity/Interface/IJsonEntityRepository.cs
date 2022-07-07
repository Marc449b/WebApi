using JsonApi.DataAccess.Repository.Base.Interface;
using Model = JsonApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;
using ModelDto = JsonApi.DataAccess.Dto.Derived.Misc.JsonEntity.JsonEntityDto;

namespace JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface
{
    public interface IJsonEntityRepository : IRepositoryBase<Model, ModelDto> { }
}
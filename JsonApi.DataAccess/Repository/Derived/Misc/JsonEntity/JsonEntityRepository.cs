using JsonApi.DataAccess.Models.Derived.Misc;
using JsonApi.DataAccess.Repository.Base;
using JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using Model = JsonApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;
using ModelDto = JsonApi.DataAccess.Dto.Derived.Misc.JsonEntity.JsonEntityDto;

namespace JsonApi.DataAccess.Repository.Derived.Misc.JsonEntity
{
    public class JsonEntityRepository : RepositoryBase<Model, ModelDto, MiscContext>, IJsonEntityRepository
    {
        public JsonEntityRepository(MiscContext context) : base(context) { }
    }
}
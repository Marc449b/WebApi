using WebApi.DataAccess.Models.Derived.Misc;
using WebApi.DataAccess.Repository.Base;
using WebApi.DataAccess.Repository.Derived.Misc.JsonEntity.Interface;
using Model = WebApi.DataAccess.Models.Derived.Misc.JsonEntity.JsonEntity;
using ModelDto = WebApi.DataAccess.Dto.Derived.Misc.JsonEntity.JsonEntityDto;

namespace WebApi.DataAccess.Repository.Derived.Misc.JsonEntity
{
    public class JsonEntityRepository : RepositoryBase<Model, ModelDto, MiscContext>, IJsonEntityRepository
    {
        public JsonEntityRepository(MiscContext context) : base(context) { }
    }
}
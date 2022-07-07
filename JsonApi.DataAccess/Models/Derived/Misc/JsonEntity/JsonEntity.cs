using Newtonsoft.Json.Linq;
using JsonApi.DataAccess.Models.Base.Entity;

namespace JsonApi.DataAccess.Models.Derived.Misc.JsonEntity
{
    public class JsonEntity : BaseEntity
    {
        public JObject Data { get; set; }
    }
}
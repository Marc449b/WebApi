using Newtonsoft.Json.Linq;
using WebApi.DataAccess.Models.Base.Entity;

namespace WebApi.DataAccess.Models.Derived.Misc.JsonObject
{
    public class JsonEntity : BaseEntity
    {
        public JObject Data { get; set; }
    }
}
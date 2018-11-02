using Newtonsoft.Json;

namespace Framework.Web.Tools.Serialization
{
    public class JsonSerializer : ISerializer
    {
        public string Serialize(object objectToSerialize)
        {
            return JsonConvert.SerializeObject(objectToSerialize);
        }
    }
}
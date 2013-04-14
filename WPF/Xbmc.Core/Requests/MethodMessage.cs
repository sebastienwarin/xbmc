using Newtonsoft.Json;
using Xbmc.Core.Base;

namespace Xbmc.Core.Requests
{
    [JsonObject]
    public class MethodMessage
    {
        [JsonProperty(PropertyName = "jsonrpc")]
        public string JsonRpc { get; set; }

        [JsonProperty(PropertyName = "method")]
        public string Method { get; set; }

        [JsonProperty(PropertyName = "id")]
        public int Id { get; set; }
    }

    [JsonObject]
    public class ParameteredMethodMessage<T> : MethodMessage
        where T : Parameters
    {
        [JsonProperty(PropertyName = "params")]
        public T Parameters { get; set; }
    }
}
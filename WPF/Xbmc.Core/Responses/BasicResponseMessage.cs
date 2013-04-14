using Newtonsoft.Json;

namespace Xbmc.Core.Responses
{
    [JsonObject]
    public sealed class BasicResponseMessage<T> : ResponseMessageBase
    {
        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }
    }
}
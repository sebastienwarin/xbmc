using Newtonsoft.Json;

namespace Xbmc.Core.Responses
{
    [JsonObject]
    public sealed class SingleValueResponseMessage<T> : ResponseMessageBase
        where T : class
    {
        [JsonProperty(PropertyName = "result")]
        public T Result { get; set; }
    }
}
using Newtonsoft.Json;
using Xbmc.Core.Model;

namespace Xbmc.Core.Responses
{
    [JsonObject]
    public sealed class GetItemResponse
    {
        [JsonProperty(PropertyName = "item")]
        public ListItemAll Item { get; set; }
    }
}
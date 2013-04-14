// ReSharper disable ClassNeverInstantiated.Global

using Newtonsoft.Json;

namespace Xbmc.Core.Model
{
    [JsonObject]
    public class ItemDetailsBase
    {
        [JsonProperty(PropertyName = "label")]
        public string Label { get; set; }
    }
}
// ReSharper disable ClassNeverInstantiated.Global

using Newtonsoft.Json;

namespace Xbmc.Core.Model
{
    [JsonObject]
    public sealed class LibraryDetailsGenre
    {
        [JsonProperty(PropertyName = "thumbnail")]
        public string Thumbnail { get; set; }

        [JsonProperty(PropertyName = "title")]
        public string Title { get; set; }

        [JsonProperty(PropertyName = "genreid")]
        public int GenreId { get; set; }
    }
}
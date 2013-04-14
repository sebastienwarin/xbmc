using System.Threading.Tasks;
using Xbmc.Core.Requests;
using Xbmc.Core.Responses;

namespace Xbmc.Core.Commands
{
    public sealed class Playlist : CommandCollection
    {
        private readonly Request _request;

        internal Playlist(Connection xbmc)
        {
            _request = new Request(xbmc);
        }

        /// <summary>Clear playlist.</summary>
        public async Task ClearAsync(int playlistId)
        {
            var method = new ParameteredMethodMessage<PlaylistIdParameters>
                             {
                                 Method = "Playlist.Clear",
                                 Parameters = new PlaylistIdParameters {PlaylistId = playlistId}
                             };

            await _request.SendRequestAsync<BasicResponseMessage<string>>(method);
        }

        /// <summary>Returns all existing playlists.</summary>
        public async Task<Model.Playlist[]> GetPlaylistsAsync()
        {
            var result = await _request.SendRequestAsync<BasicResponseMessage<Model.Playlist[]>>("Playlist.GetPlaylists");
            return result.Result;
        }
    }
}
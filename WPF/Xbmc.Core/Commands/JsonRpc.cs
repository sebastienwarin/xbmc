using System.Threading.Tasks;
using Xbmc.Core.Model;
using Xbmc.Core.Requests;
using Xbmc.Core.Responses;

namespace Xbmc.Core.Commands
{
    public sealed class JsonRpc : CommandCollection
    {
        private readonly Request _request;

        internal JsonRpc(Connection xbmc)
        {
            _request = new Request(xbmc);
        }

        /// <summary>Ping responder.</summary>
        public async Task<bool> PingAsync()
        {
            var result = await _request.SendRequestAsync<BasicResponseMessage<string>>("JSONRPC.Ping");
            return result.Result.ToUpperInvariant() == "PONG";
        }

        /// <summary>Retrieve the JSON-RPC protocol version.</summary>
        public async Task<JsonRpcVersion> VersionAsync()
        {
            var result = await _request.SendRequestAsync<BasicResponseMessage<JsonRpcVersion>>("JSONRPC.Version");
            return result.Result;
        }
    }
}
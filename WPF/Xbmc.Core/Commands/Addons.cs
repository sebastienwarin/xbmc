using Xbmc.Core.Requests;

namespace Xbmc.Core.Commands
{
    public sealed class Addons : CommandCollection
    {
        private readonly Request _request;

        internal Addons(Connection xbmc)
        {
            _request = new Request(xbmc);
        }

    }
}
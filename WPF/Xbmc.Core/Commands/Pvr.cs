using Xbmc.Core.Requests;

namespace Xbmc.Core.Commands
{
    public sealed class Pvr : CommandCollection
    {
        private readonly Request _request;

        internal Pvr(Connection xbmc)
        {
            _request = new Request(xbmc);
        }

    }
}
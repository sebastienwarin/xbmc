using Xbmc.Core.Requests;

namespace Xbmc.Core.Commands
{
    public sealed class Gui : CommandCollection
    {
        private readonly Request _request;

        internal Gui(Connection xbmc)
        {
            _request = new Request(xbmc);
        }

    }
}
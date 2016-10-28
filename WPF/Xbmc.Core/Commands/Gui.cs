using System.Threading.Tasks;
using Xbmc.Core.Requests;
using Xbmc.Core.Responses;

namespace Xbmc.Core.Commands
{
    public sealed class Gui : CommandCollection
    {
        private readonly Request _request;

        internal Gui(Connection xbmc)
        {
            _request = new Request(xbmc);
        }


        /// <summary>Go to previous/next/specific item in the playlist.</summary>
        public async Task<string> ShowNotification(string title, string message, string image = "", int displaytime = 5000)
        {
            var method = new ParameteredMethodMessage<ShowNotificationParameters>
            {
                Method = "GUI.ShowNotification",
                Parameters = new ShowNotificationParameters
                {
                    DisplayTime = displaytime,
                    Message = message,
                    Title = title,
                    Image = image
                }
            };

            var result = await _request.SendRequestAsync<BasicResponseMessage<string>>(method);
            return result.Result;
        }
    }
}
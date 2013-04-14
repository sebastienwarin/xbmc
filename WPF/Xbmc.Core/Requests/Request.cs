using System;
using System.Net;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Xbmc.Core.Base;
using Xbmc.Core.Responses;

namespace Xbmc.Core.Requests
{
    internal sealed class Request
    {
        private readonly Connection _xbmc;

        internal Request(Connection xbmc)
        {
            _xbmc = xbmc;
        }

        internal async Task<T> SendRequestAsync<T>(string methodName)
            where T : ResponseMessageBase
        {
            var methodMessage = new MethodMessage
                                    {
                                        Method = methodName
                                    };

            return await SendRequestAsync<T>(methodMessage);
        }

        internal async Task<T> SendRequestAsync<T>(MethodMessage methodMessage)
            where T : ResponseMessageBase
        {
            int id = RandomNumber.GetRandomNumber(1, int.MaxValue);
            methodMessage.Id = id;
            methodMessage.JsonRpc = "2.0";

            string serialization = JsonConvert.SerializeObject(methodMessage, Formatting.None);

            var client = new WebClient
                             {
                                 Credentials = new NetworkCredential(_xbmc.Login, _xbmc.Password)
                             };
            string resultStr = await UploadStringAsync(client, _xbmc.BaseUrl, serialization);

            var result = JsonConvert.DeserializeObject<T>(resultStr);

            if (result.Id != methodMessage.Id)
                throw new RequestException(methodMessage.Method, "The Id received does not match the one that was sent.");

            if (result.Error != null)
                throw new RequestException(methodMessage.Method, result.Error.ToString());

            return result;
        }

        private static Task<string> UploadStringAsync(WebClient client, string url, string data)
        {
            var tcs = new TaskCompletionSource<string>();

            client.UploadStringCompleted +=
                (s, e) =>
                {
                    if (e.Error == null)
                        tcs.SetResult(e.Result);
                    else
                        tcs.SetException(e.Error);
                };

            client.UploadStringAsync(new Uri(url), data);

            return tcs.Task;
        }
    }
}
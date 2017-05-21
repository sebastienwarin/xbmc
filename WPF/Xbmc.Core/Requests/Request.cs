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

            string serialization = JsonConvert.SerializeObject(methodMessage, Formatting.None,
                new JsonSerializerSettings
                {
                    NullValueHandling = NullValueHandling.Ignore
                });

            using (var client = new WebClient()
            {
                Encoding = System.Text.Encoding.UTF8,
                Credentials = new NetworkCredential(_xbmc.Login, _xbmc.Password)
            })
            {
                string resultStr = await client.UploadStringTaskAsync(_xbmc.BaseUrl, serialization);
                var result = JsonConvert.DeserializeObject<T>(resultStr);

                if (result.Id != methodMessage.Id)
                    throw new RequestException(methodMessage.Method, "The Id received does not match the one that was sent.");

                if (result.Error != null)
                    throw new RequestException(methodMessage.Method, result.Error.ToString());

                return result;
            }           
        }
    }
}
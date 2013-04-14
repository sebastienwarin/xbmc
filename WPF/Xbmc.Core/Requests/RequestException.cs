using System;

namespace Xbmc.Core.Requests
{
    public sealed class RequestException : Exception
    {
        public string MethodName { get; private set; }

        public RequestException(string methodName, string message)
            : base(message)
        {
            MethodName = methodName;
        }
    }
}
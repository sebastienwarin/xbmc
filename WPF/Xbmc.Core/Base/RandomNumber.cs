using System;

namespace Xbmc.Core.Base
{
    internal static class RandomNumber
    {
        private static readonly Random getrandom = new Random();
        private static readonly object syncLock = new object();

        internal static int GetRandomNumber(int min, int max)
        {
            lock (syncLock)
            {
                return getrandom.Next(min, max);
            }
        }
    }
}
using System;
using System.Threading;

namespace Koans.Utils
{
    public class ThreadUtils
    {
        public static void WaitUntil(Func<bool> func)
        {
            while (!func())
            {
                Thread.Sleep(100);
            }
        }
    }
}
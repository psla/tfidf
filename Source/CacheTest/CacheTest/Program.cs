using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace CacheTest
{
    class Program
    {
        static void Main(string[] args)
        {
            bool complete = false;
            var t = new Thread(() =>
                                   {
                                       bool toggle = false;
                                       while (!complete) { toggle = !toggle; }
                                   });
            t.Start();
            Thread.Sleep(1000);

            complete = true;
            t.Join();
        }
    }
}

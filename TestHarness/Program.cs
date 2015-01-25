using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using Server;

namespace TestHarness
{
    class Program
    {
        static void Main(string[] args)
        {
            OculusRift x = new OculusRift();
            x.Init();
            while (true)
            {
                Console.WriteLine(x.GetLiveInfo());
                Console.WriteLine(x.Initialised);
                Thread.Sleep(1000);
            }

        }
    }
}

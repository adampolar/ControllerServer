using Fleck;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Sockets;
using System.Globalization;

namespace Server
{
    class Program
    {
        static void Main(string[] args)
        {
            using (var server = new Server())
            {
                server.Init();
            }
        }
    }
}

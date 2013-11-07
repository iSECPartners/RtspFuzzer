using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace EvilRtspServer
{
    class Program
    {
        static void Main(string[] args)
        {
            if (args.Length != 1)
            {
                Console.WriteLine("usage: EvilRtspServer.exe response_directory");
                return;
            }

            string sourceFolder = args[0];
            RtspServer server = new RtspServer(sourceFolder, 554);
            server.Start();
            while (true)
            {
                server.Accept();
            }
        }
    }
}

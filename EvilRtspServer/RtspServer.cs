using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Text.RegularExpressions;
using System.Threading.Tasks;

namespace EvilRtspServer
{
    public class RtspServer
    {
        private string _responseFolder;
        private TcpListener _tcpListener;

        public RtspServer(string responsesFolder, int listenPort)
        {
            _tcpListener = new TcpListener(IPAddress.Any, listenPort);
            _responseFolder = responsesFolder;
        }

        public void Start()
        {
            _tcpListener.Start();
        }

        private List<string> ParseResponseFolder()
        {

            List<string> responses = new List<string>();

            string[] responseFiles = Directory.GetFiles(_responseFolder, "action_*_Output_*.txt");
            foreach (string responseFile in responseFiles)
            {
                using (StreamReader sr = new StreamReader(responseFile))
                {
                    string responseData = sr.ReadToEnd();
                    responses.Add(responseData);
                }
            }

            return responses;
        }

        public void Accept()
        {
            Console.WriteLine("Waiting for clients...");
            TcpClient client = _tcpListener.AcceptTcpClient();
            Console.WriteLine("Got a client!");

            List<string> responses = ParseResponseFolder();

            try
            {
                using (StreamReader sr = new StreamReader(client.GetStream()))
                {
                    using (StreamWriter sw = new StreamWriter(client.GetStream()))
                    {
                        for (int i = 0; i < responses.Count; i++)
                        {
                            string lineRead = sr.ReadLine();
                            while (!string.IsNullOrEmpty(lineRead))
                            {
                                Console.WriteLine(lineRead);
                                lineRead = sr.ReadLine();
                            }
                            Console.WriteLine();

                            string currentResponse = responses[i];
                            Console.WriteLine(currentResponse);
                            sw.Write(currentResponse);
                            sw.Flush();
                        }
                    }
                }
            }
            catch (Exception ex)
            {
                Console.WriteLine("Exception: {0}", ex.Message);
            }
        }
    }
}

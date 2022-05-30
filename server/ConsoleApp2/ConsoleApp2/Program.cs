using System;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace ServerSide
{
    class Program
    {
        public static int Main(String[] args)
        {
            StartServer();
            return 0;
        }
        public static void StartServer()
        {
            // Get Host IP Address that is used to establish a connection  
            // In this case, we get one IP address of localhost that is IP : 127.0.0.1  
            // If a host has multiple addresses, you will get a list of addresses 
            int counter = 0;
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 3000);
            // Create a Socket that will use Tcp protocol

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // A Socket must be associated with an endpoint using the Bind method  
            listener.Bind(localEndPoint);
            // Specify how many requests a Socket can listen before it gives Server busy response.  
            // We will listen 10 requests at a time  
            listener.Listen(10);
            while (true)
            {
                try
                {
                    Console.WriteLine("Waiting for a connection...");
                    Socket handler = listener.Accept();
                    counter++;
                    HandleClient client = new HandleClient();
                    client.startClient(handler, Convert.ToString(counter));
                }
                catch (Exception e)
                {
                    Console.WriteLine(e.ToString());
                }
            }
        }


    }
}

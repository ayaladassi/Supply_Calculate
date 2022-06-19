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
            //   המשמש ליצירת חיבור IP  קבל כתובת    
            // 127.0.0.1 שהוא localhost-  IP במקרה זה לקחנו  
            // אם יש כמה כתובות נקבל רשימה של כתובות
            int counter = 0;
            IPHostEntry host = Dns.GetHostEntry("localhost");
            IPAddress ipAddress = host.AddressList[0];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 3000);
            // tcp צור סוקט שישתמש בפרוטקול 

            Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
            // שיוך הסוקט לפורט ולהוסט   
            listener.Bind(localEndPoint);
            // כמה בקשות אפשר לקבל 
            // 10 משתמשים
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

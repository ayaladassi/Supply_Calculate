using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.IO;

namespace ServerSide
{
    class HandleClient
    {
        Socket clientSocket;
        string clNo;
        public void startClient(Socket inClientSocket, string clineNo)
        {
            this.clientSocket = inClientSocket;
            this.clNo = clineNo;
            Thread ctThread = new Thread(go);
            ctThread.Start();
        }

        private void go()
        {
            // Incoming data from the client.    
            string data = null;
            byte[] bytes = null;
            byte[] by = null;
            string msg = null;
            bytes = new byte[1024];

            try
            {
                while (true)
                {
                    bytes.Clone();
                    int bytesRec = clientSocket.Receive(bytes);
                    data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                    if (data.IndexOf("<EOF>") > -1)
                    {
                        break;
                    }
                    string text =File.ReadAllText(@"C:\Users\labadmin\Documents\GitHub\Supply_Calculate\server\ConsoleApp2\castemers.txt");
                   string a = ","+data + ",";
                    if (text.Contains(a))
                    {
                        msg = "true";
                        by = Encoding.UTF8.GetBytes(msg);
                    }
                    else
                    {
                        msg = "false";
                        by = Encoding.UTF8.GetBytes(msg);
                    }
                    int bytesSent = clientSocket.Send(by);

                }
            }
            catch (Exception ex)
            {
                Console.WriteLine(" >> " + ex.ToString());
            }
            finally
            {
                clientSocket.Shutdown(SocketShutdown.Both);
                clientSocket.Close();
            }

        }
    }
}

using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Data;
using System.Drawing;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;
using System.Net;
using System.Net.Sockets;

namespace Supply_Calculate
{
    public partial class Index : Form
    {
        IPHostEntry host;
        IPAddress ipAddress;
        IPEndPoint remoteEP;
        Socket socket;
        //משתנה אסקי ששולח את הנתונים בסוקט
        byte[] bytes = new byte[1024];
        public void StartClient()
        {
            try
            {


// התחבר לשרת מרוחק
// קבל כתובת IP מארח המשמשת ליצירת חיבור
// במקרה זה, אנו מקבלים כתובת IP אחת של localhost שהיא IP : 127.0.0.1
// אם למארח יש מספר כתובות, תקבל רשימה של כתובות
                host = Dns.GetHostEntry("localhost");
                ipAddress = host.AddressList[0];
                remoteEP = new IPEndPoint(ipAddress, 3000);

                // Create a TCP/IP  socket.    
                socket = new Socket(ipAddress.AddressFamily,
                    SocketType.Stream, ProtocolType.Tcp);

                // Connect the socket to the remote endpoint. Catch any errors.    
                try
                {
                    // Connect to Remote EndPoint  
                    socket.Connect(remoteEP);
                    Console.WriteLine("Socket connected to {0}",
                        socket.RemoteEndPoint.ToString());
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException : {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException : {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception : {0}", e.ToString());
                }

            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
        public Index()
        {
            InitializeComponent();
            StartClient();

        }

        private void textBox1_TextChanged(object sender, EventArgs e)
        {

        }

        private void button1_Click(object sender, EventArgs e)
        {
            int[] arr = { 1, 2, 3 };
            string sx = string.Join(",", arr);
            byte[] msg1 = Encoding.UTF8.GetBytes(sx);


            byte[] msg = Encoding.UTF8.GetBytes(textBox1.Text);

            // Send the data through the socket.    
            int bytesSent = socket.Send(msg);

            // Receive the response from the remote device.    
            int bytesRec = socket.Receive(bytes);
            string s = Encoding.UTF8.GetString(bytes, 0, bytesRec);

            // Displays the MessageBox.
            //MessageBox.Show(s);
            if (s=="true")
            {
                Form1 f1 = new Form1();
                f1.Show();
               
            }
            else
            {
                MessageBox.Show("הכנס קוד משתמש תקין");
            }

        }
    }
}

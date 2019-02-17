using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CHAT_MSDOS_SERVIDOR
{
    class Program
    {
        static void Main(string[] args)
        {
            /* Here we create an address which is going to listen to any ip from
             * this port. 
             */
            IPEndPoint ipep = new IPEndPoint(IPAddress.Any, 1234);

            // Here we create a shocket
            Socket sock = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);
            try
            {
                // Here we bind the socket to de address.
                sock.Bind(ipep);

                //Here we put in listen the socket
                sock.Listen(1);
                Console.WriteLine("Listening...");

                /* The program waits until the server is conneceted and it saves
                 * the response in other socket.
                 */
                Socket client = sock.Accept();
                Console.WriteLine("Succsefully Connected");

                /* Here we have an string wich is where finaly is going to be stored
                 * the message.
                 */
                string data;

                /* In this array we save the array length we are going to receive
                 * from the client to modify it of the server array later.
                 */
                int array_size;

                //In this byte array we save the message bytes.
                byte[] receive_info = new byte[255];

                do
                {
                    //Here we store the length of the array in array_size.
                    array_size = client.Receive(receive_info, 0, receive_info.Length, 0);
                    
                    //Here we resize the array of the server
                    Array.Resize(ref receive_info, array_size);

                    //Here we recibe the bytes and save it in the receive_info array.
                    client.Receive(receive_info);

                    //Here we convert the bytes of the array in an string
                    data = Encoding.Default.GetString(receive_info);

                    //Here we show the string
                    Console.WriteLine(data);
                } while (data != ".");

                sock.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
    }
}

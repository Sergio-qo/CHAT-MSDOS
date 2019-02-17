using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net;
using System.Net.Sockets;

namespace CHAT_MSDOS_client
{
    class Program
    {
        static void Main(string[] args)
        {
            /* In this line is created an object Socket wich later is going to be 
             * connected to localhost or the publilc ip of the network where we have 
             * the server.
             */
            Socket client = new Socket(AddressFamily.InterNetwork, SocketType.Stream, ProtocolType.Tcp);

            /* In this line is defined the ip wich is going to have the socket and the
             * port wher it's going to work.
             */
            IPEndPoint ipep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), 1234);


            /* Here we try to connect and if it can't connect returns "Error".
             */
            try
            {
                /* Here whe connect the socket to the before created address.
                 */
                client.Connect(ipep);
                Console.WriteLine("Succesfully connected");

                /* Here we create an string where we ar going to store the text we are
                 * going to send.
                 */
                string data;

                /* Here is delcared an array wich is going to
                 * contain the message.
                 */
                byte[] send = new byte[100];

                /* In this loop we ask for the message and save it in the array
                 * to send it.
                 */
                do
                {
                    Console.Write("To send: ");
                    data = Console.ReadLine();
                    /* Here we convert the string in bytes using the 
                     * GetBytes method.
                     */
                    send = Encoding.Default.GetBytes(data);

                    // This line sends the array
                    client.Send(send, 0, send.Length, 0);
                } while (true);

                client.Close();
            }
            catch (Exception)
            {
                Console.WriteLine("Error");
            }
        }
    }
}

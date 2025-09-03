using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketProgrammingClient
{
    public class SocketClient
    {
        static int Main(string[] args)
        {
            StartClient();
            return 0;
        }

        public static void StartClient()
        {
            Console.Write("Write endpoint IP address: ");

            string IpAddress = Console.ReadLine();

            while (string.IsNullOrEmpty(IpAddress))
            {
                IpAddress = Console.ReadLine();
            }

            try
            {
                // Forbind til en fjern server
                // Hent Host IP adressen der er brugt til at oprette en forbindelse
                // I dette scenarie, henter vi en IP adresse af localhost IP:  127.0.0.1
                // Hvis en host har flere adresser, får du en liste af adresser
                IPAddress ipAddress = IPAddress.Parse(IpAddress);
                IPEndPoint remoteEP = new IPEndPoint(ipAddress, 11000);

                // Opret en TCP/IP socket
                Socket sender = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // Forbind socket til endpointet. Fang alle fejl.
                try
                {
                    // Forbind til endpoint
                    sender.Connect(remoteEP);

                    Console.WriteLine($"Socket connected to {sender.RemoteEndPoint.ToString()}");

                    // Indgående data fra server
                    string data = null;
                    byte[] bytes = new byte[1024];

                    while (true)
                    {
                        // Kod dataen ind til et byte array
                        Console.Write("You: ");
                        string text = Console.ReadLine();
                        byte[] msg = Encoding.UTF8.GetBytes($"{text}");

                        // Send data igennem socket
                        int bytesSent = sender.Send(msg);

                        if (text == "exit")
                        {
                            break;
                        }

                        int bytesRec = sender.Receive(bytes);
                        data = Encoding.UTF8.GetString(bytes, 0, bytesRec);
                        Console.WriteLine($"\nText received: {data}");

                        if (data == "exit")
                        {
                            break;
                        }
                    }

                    // Frigør socket
                    sender.Shutdown(SocketShutdown.Both);
                    sender.Close();
                }
                catch (ArgumentNullException ane)
                {
                    Console.WriteLine("ArgumentNullException: {0}", ane.ToString());
                }
                catch (SocketException se)
                {
                    Console.WriteLine("SocketException: {0}", se.ToString());
                }
                catch (Exception e)
                {
                    Console.WriteLine("Unexpected exception: {0}", e.ToString());
                }
            }
            catch (Exception e)
            {
                Console.WriteLine(e.ToString());
            }
        }
    }
}

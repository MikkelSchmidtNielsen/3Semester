using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace SocketProgramming
{
    public class SocketListener
    {
        static int Main(string[] args)
        {
            StartServer();
            return 0;
        }

        public static void StartServer()
        {
            // Hent Host IP adressen, som bruges til at etablere en forbindelse
            // I dette scenarie, får vi en IP adresse af localhost som er IP: 127.0.0.1
            // Hvis en host har flere adresser, får du en liste af adresser
            IPHostEntry host = Dns.GetHostEntry(Dns.GetHostName());
            IPAddress ipAddress = host.AddressList[3];
            IPEndPoint localEndPoint = new IPEndPoint(ipAddress, 11000);

            Console.WriteLine(host.AddressList[3].ToString());

            try
            {
                // Opret en Socket som vil bruge TCP protocol
                Socket listener = new Socket(ipAddress.AddressFamily, SocketType.Stream, ProtocolType.Tcp);

                // En socket skal være associeret med et slutpunkt ved brug af Bind metoden
                listener.Bind(localEndPoint);

                // Specificer hvor mange request en socket kan høre før den giver et "Server busy" svar
                // Vi lytter til 10 anmodninger ad gangen
                listener.Listen(10);

                Console.WriteLine("Waiting for a connection");
                Socket handler = listener.Accept();

                // Indgående data fra clienten
                string data = null;
                byte[] bytes = new byte[1024];

                while (true)
                {
                    int bytesRec = handler.Receive(bytes);
                    data = Encoding.ASCII.GetString(bytes, 0, bytesRec);
                    Console.WriteLine($"\nText received: {data}");

                    if (data.ToLower() == "exit")
                    {
                        break;
                    }

                    Console.Write("You: ");
                    string text = Console.ReadLine();
                    byte[] msg = Encoding.ASCII.GetBytes(text);
                    handler.Send(msg);

                    if (text.ToLower() == "exit")
                    {
                        break;
                    }
                }

                handler.Shutdown(SocketShutdown.Both);
                handler.Close();
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.ToString());
            }

            Console.WriteLine("\n Press any key to continue...");
            Console.ReadKey();
        }
    }
}

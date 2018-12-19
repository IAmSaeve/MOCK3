using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

namespace UDPSensorReceiver
{
    class Program
    {
        static void Main(string[] args)
        {
            UdpClient udp = new UdpClient(7001);
            IPEndPoint RemoteEndPoint = new IPEndPoint(IPAddress.Any, 7001);

            while (true)
            {
                Byte[] receiveBytes = udp.Receive(ref RemoteEndPoint);

                string receivedData = Encoding.ASCII.GetString(receiveBytes);
                if (receivedData.ToLower().Contains("stop"))
                {
                    break;
                }

                var dataLines = receivedData.Split("\r\n");
                var Presure = double.Parse(dataLines[0].Split(" ")[1].Replace(",", "."));
                var Humidity = double.Parse(dataLines[1].Split(" ")[1].Replace(",", "."));
                var Temperature = double.Parse(dataLines[2].Split(" ")[1].Replace(",", "."));

                Console.WriteLine("Real numercal values: P = " + Presure + " H = " + Humidity + " T = " + Temperature);
            }
            Console.Clear();
            Console.WriteLine("Press any key to continue...");
            Console.ReadKey();
        }
    }
}

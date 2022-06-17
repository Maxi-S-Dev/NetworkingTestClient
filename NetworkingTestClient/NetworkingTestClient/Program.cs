// See https://aka.ms/new-console-template for more information

using System.Net.Sockets;
using System.Text;

connection:
try
{
    TcpClient client = new TcpClient("192.168.2.50", 1302);
    string message = "Hello I am Max";

    int byteCount = Encoding.ASCII.GetByteCount(message);
    byte[] sendData = new byte[byteCount];
    sendData = Encoding.ASCII.GetBytes(message);

    NetworkStream stream = client.GetStream();
    stream.Write(sendData, 0, sendData.Length);
    Console.WriteLine("sending data to server...");

    StreamReader reader = new StreamReader(stream);
    string? response = reader.ReadLine();
    Console.WriteLine(response);

    stream.Close();
    client.Close();
    Console.ReadKey();
}
catch
{
    Console.WriteLine("Failed to Connect");
    goto connection;
}

using System;
using System.Net;
using System.Net.Sockets;
using System.Text;

int listenPort = 11000;
UdpClient socket = new UdpClient(listenPort);
IPEndPoint? clientSocket = null;

try
{
    while (true)
    {
        Console.WriteLine();
        Console.WriteLine("Waiting from message from the Client...\n");

        byte[] bytes = socket.Receive(ref clientSocket);

        Console.WriteLine($" {Encoding.Unicode.GetString(bytes, 0, bytes.Length)}\n");

        Console.WriteLine("Write a message to the Client:\n");
        string? message = Console.ReadLine();
        byte[] sendbuf = Encoding.Unicode.GetBytes(message ?? "Null");

        socket.Send(sendbuf, sendbuf.Length, clientSocket);
    }
}
catch (SocketException e)
{
    Console.WriteLine(e);
}
finally
{
    socket.Close();
}
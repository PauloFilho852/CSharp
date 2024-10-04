using static System.Console;
using System.Net;
using System.Net.Sockets;
using System.Text;


const int listenerPortNumber = 13;
TcpListener listenerSocket = new(IPAddress.Any, listenerPortNumber);

listenerSocket.Start();

TcpClient? tcpConnection = null;
NetworkStream? networkStream = null;

try
{
    Write("Waiting for connection...");

    tcpConnection = listenerSocket.AcceptTcpClient();

    WriteLine($"Connection accepted: {tcpConnection.Client.RemoteEndPoint}.");

    networkStream = tcpConnection.GetStream();

    while (true)
    {
        string? message = ReadLine();
        byte[] byteTime = Encoding.Unicode.GetBytes(message ?? "NULL");
        networkStream.Write(byteTime, 0, byteTime.Length);
        
        byte[] bytesBuffer = new byte[1024];
        int bytesRead = networkStream.Read(bytesBuffer, 0, bytesBuffer.Length);
        WriteLine(Encoding.Unicode.GetString(bytesBuffer, 0, bytesRead));
    }
}
catch (Exception e)
{
    WriteLine(e.ToString());
}

if (networkStream != null)
    networkStream.Close();

if (tcpConnection != null)
    tcpConnection.Close();

listenerSocket.Stop();

ReadKey();



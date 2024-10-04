using static System.Console;
using System.Net;
using System.Net.Sockets;
using System.Text;

const int serverPortNumber = 13;
IPAddress serverIP = IPAddress.Parse("192.168.0.130");
IPEndPoint serverSocket = new(serverIP, serverPortNumber);

TcpClient? tcpConnection = null;
NetworkStream? networkStream = null;

try
{
    tcpConnection = new();
    tcpConnection.Connect(serverSocket);

    WriteLine("Requesting connetion...");

    networkStream = tcpConnection.GetStream();

    while (true)
    {
        byte[] bytesBuffer = new byte[1024];
        int bytesRead = networkStream.Read(bytesBuffer, 0, bytesBuffer.Length);
        WriteLine(Encoding.Unicode.GetString(bytesBuffer, 0, bytesRead));

        string? message = ReadLine();
        byte[] writerBytes = Encoding.Unicode.GetBytes(message ?? "NULL");
        networkStream.Write(writerBytes, 0, writerBytes.Length);

        if (message == "fim")
            break;
    }
}
catch (Exception e)
{
    WriteLine(e.ToString());
}

if (tcpConnection != null)
    tcpConnection.Close();

if (networkStream != null)
    networkStream.Close();

ReadKey();



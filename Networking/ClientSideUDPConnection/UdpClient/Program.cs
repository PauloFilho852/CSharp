using System.Net;
using System.Net.Sockets;
using System.Text;


Socket socket = new Socket(AddressFamily.InterNetwork, SocketType.Dgram, ProtocolType.Udp);
IPAddress serverIP = IPAddress.Parse("192.168.0.130");
IPEndPoint serverSocket = new IPEndPoint(serverIP, 11000);

try
{
    while (true)
    {
        Console.WriteLine("Write a message to the Server:\n");
        string? message = Console.ReadLine();
        byte[] sendbuf = Encoding.Unicode.GetBytes(message ?? "Null");

        socket.SendTo(sendbuf, serverSocket);

        Console.WriteLine();
        Console.WriteLine("Waiting message from the Server...\n");

        byte[] bytes = new byte[1024];
        int bytesLength = socket.Receive(bytes);

        Console.WriteLine($"{Encoding.Unicode.GetString(bytes, 0, bytesLength)}\n");
    }

}
catch (Exception e)
{
    Console.WriteLine(e.Message);    
}
finally
{
    socket.Close();
}


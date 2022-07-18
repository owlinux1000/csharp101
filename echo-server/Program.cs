using System;
using System.Net;
using System.Net.Sockets;
using System.Text;
namespace EchoServer;
class Program {
    static void Main(string[] args) {        
        IPAddress host = IPAddress.Parse("127.0.0.1");
        int port = 8888;
        IPEndPoint ipe = new IPEndPoint(host, port);
        Console.WriteLine("[+] Running {0}:{1}", host, port);
        Socket listener = new Socket(ipe.AddressFamily, SocketType.Stream, ProtocolType.Tcp);
        listener.Bind(ipe);
        listener.Listen(5);

        Socket handler = listener.Accept();
        for(;;) {
            byte[] buf = new byte[8192];
            int n = handler.Receive(buf);
            if(n == 0) {
                break;
            }
            string data = Encoding.UTF8.GetString(buf, 0, n);
            Console.Write(data);
            handler.Send(buf);
        }
        handler.Shutdown(SocketShutdown.Both);
        handler.Close();

    }
}
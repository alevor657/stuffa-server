using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SocketServer
{
    public class Server : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            Console.WriteLine(e.Data.ToString());
            var msg = e.Data.ToString().ToUpper();

            Send(msg);
        }
    }

    public class Program
    {
        public static void Main(string[] args)
        {
            var wssv = new WebSocketServer("ws://localhost");
            wssv.AddWebSocketService<Server>("/Server");
            wssv.Start();
            Console.WriteLine("Listening...");
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}

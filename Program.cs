using System;
using WebSocketSharp;
using WebSocketSharp.Server;

namespace SocketServer
{
    public class Handler : WebSocketBehavior
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
            var wssv = new WebSocketServer("ws://localhost:1337");
            wssv.AddWebSocketService<Handler>("/Server");
            wssv.Start();
            Console.WriteLine($"Listening on {wssv.Address}:{wssv.Port}");
            Console.ReadKey(true);
            wssv.Stop();
        }
    }
}

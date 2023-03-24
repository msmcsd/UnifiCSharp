using WebSocketSharp;
using WebSocketSharp.Server;

namespace UnifiDesktop.Socket
{
    internal abstract class BaseBehavior : WebSocketBehavior
    {
        protected override void OnMessage(MessageEventArgs e)
        {
            //Send(e.Data);
            Sessions.Broadcast(e.Data);
        }
    }
}

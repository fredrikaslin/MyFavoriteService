using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Net.WebSockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;
using System.Web;
using System.Web.Http;
using System.Web.WebSockets;

namespace MyFavoriteApi.Controllers
{
    [RoutePrefix("api")]
    public class MessageWebsocketController : ApiController
    {
        [HttpGet]
        [Route("notification")]
        public HttpResponseMessage GetMessage()
        {
            if (HttpContext.Current.IsWebSocketRequest)
            {
                HttpContext.Current.AcceptWebSocketRequest(ProcessRequestInternal);
            }

            return new HttpResponseMessage(HttpStatusCode.SwitchingProtocols);
        }

        private async Task ProcessRequestInternal(AspNetWebSocketContext context)
        {
            var message = "hej daniel - hheeheheheheheee....";

            WebSocket socket = context.WebSocket;
            //WebSocket socket = context.WebSocket;
            ArraySegment<byte> buffer = new ArraySegment<byte>(new byte[1024]);
            buffer = new ArraySegment<byte>(Encoding.UTF8.GetBytes(message));
            await socket.SendAsync(buffer, WebSocketMessageType.Text, true, CancellationToken.None);
        }
    }
}
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.WebSockets;
using System.Threading.Tasks;
using System.Web;
using System.Web.WebSockets;

namespace WebsocketTest
{
    public class MessageService : IHttpHandler
    {
        public void ProcessRequest(HttpContext context)
        {

            if (context.IsWebSocketRequest)
            {
                context.AcceptWebSocketRequest(ProcessRequestInternal);
            }

            else
            {
                context.Response.StatusCode = 400;
            }
        }

        public bool IsReusable
        {
            get
            {
                return false;
            }
        }

        private async Task ProcessRequestInternal(AspNetWebSocketContext context)
        {
            WebSocket socket = context.WebSocket;

            while (true)
            {
                //Write your code here to process the request
            }

        }
    }
}
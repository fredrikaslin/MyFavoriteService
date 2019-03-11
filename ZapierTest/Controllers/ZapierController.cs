using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace ZapierTest.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ZapierController : ControllerBase
    {
        string apiKey = "2345";
        static string _mess = "";

        [HttpGet]
        public ActionResult<IEnumerable<string>> Get(string apikey)
        {
            //var authHeader = HttpContext.Request; ;
            //var req_apiKey = HttpContext.Request.Headers["apikey"];
            if(apikey == apiKey)
            {
                return new string[] { "hej", "hejsan", "hejhej" };
            }
            return BadRequest();

        }

        [HttpGet]
        [Route("getZap")]
        public ActionResult<IEnumerable<Message>> Get()
        {

            return new Message[] { new Message() { Id = "zap" }, new Message() { Id = "zapppp2" } };


        }

        [HttpGet]
        [Route("pollme")]
        public List<Message> GenerateMessage()
        {
            var list = new List<Message>();
            for(int index = 0; index < DateTime.Now.Minute; index++)
            {
                list.Add(new Message() { Id = index.ToString(), MessageText = _mess});
            }

            return list;
        }

        [HttpPost]
        [Route("postMe")]
        public ActionResult PostMe(string message)
        {
            _mess = message;
            return Ok();
        }

    }

    public class Message
    {
        public string Id { get; set; }
        public string MessageText { get; set; }
    }
}

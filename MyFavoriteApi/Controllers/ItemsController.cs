using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyFavoriteApi.Controllers
{
    public class ItemsController : ApiController
    {
        public IHttpActionResult Get(int id)
        {
            var item = id * id;

            return Ok(item);
        }
    }
}
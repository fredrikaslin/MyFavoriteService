using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;

namespace MyFavoriteApi.Controllers
{
    public class ItemsController : ApiController
    {
        delegate int testDel(int i);
        public IHttpActionResult Get(int id)
        {
            testDel delItems = x => x * x;

            return Ok(delItems(id));
        }
    }
}
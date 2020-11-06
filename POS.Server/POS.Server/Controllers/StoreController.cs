using POS.Server.Controllers.Helper;
using POSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Http;
using TestDemo;

namespace POS.Server.Controllers
{
    public class StoreController : ApiController
    {
        public IHttpActionResult Get()
        {
            List<Store> stores = DBManager<Store>.GetAll();
            return Json(new Message<Store>
            {
                code = 0,
                isSuccess = true,
                Data = stores
            }) ;
        }
    }
}
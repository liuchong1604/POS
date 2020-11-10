using Newtonsoft.Json.Linq;
using POS.Client1.Controllers.HttpHelper;
using POSmodel;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace POS.Client1.Controllers
{
    public class StoreManagerController:Controller
    {
        string url = "http://localhost:44329/api/Store/";
        public ActionResult Index()
        {
            return View();
        }

        [HttpPost]
        public ActionResult GetStories()
        {
            JObject json = HttpClient.GetHttpResponse(url, -1);
            return Json(new Message<Store>
            {
                Code = 200,
                isSeccess = Convert.ToBoolean(json["isSeccess"]),
                Data = json["Data"].ToObject<List<Store>>()
            });
        }
    }
}
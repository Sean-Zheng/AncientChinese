using AncientChinese.Models.SqlOperater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AncientChinese.Controllers
{
    public class AppreciateController : ApiController
    {
        [HttpGet]
        public IHttpActionResult List()
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.List();
            return Json(list);
        }
        [HttpGet]
        public IHttpActionResult Detail(string id)
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.Detail(id);
            return Json(list);
        }
    }
}
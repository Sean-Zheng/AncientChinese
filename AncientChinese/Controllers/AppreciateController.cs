using AncientChinese.Models.SqlOperater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AncientChinese.Controllers
{
    /// <summary>
    /// 名家鉴赏
    /// </summary>
    public class AppreciateController : ApiController
    {
        [HttpGet]
        public IHttpActionResult AuthorsList()
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.GetAuthors();
            return Json(list);
        }
        [HttpGet]
        public IHttpActionResult TimesList()
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.GetTimesList();
            return Json(list);
        }
        [HttpGet]
        public IHttpActionResult Authors(string authors)
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.Authors(authors);
            return Json(list);
        }
        [HttpGet]
        public IHttpActionResult Times(string times)
        {
            AppreciateOperater operater = new AppreciateOperater();
            var list = operater.Times(times);
            return Json(list);
        }
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
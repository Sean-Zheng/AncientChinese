using AncientChinese.Models;
using AncientChinese.Models.SqlOperater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AncientChinese.Controllers
{
    public class CopybookController : ApiController
    {
        /// <summary>
        /// 获取字帖列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult List()
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<Copybook> copybooks = operater.GetCopybooks();
            return Json(copybooks);
        }
        [HttpGet]
        public IHttpActionResult List(int type)
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<Copybook> copybooks = operater.GetCopybooks(type);
            return Json(copybooks);
        }
        /// <summary>
        /// 列表
        /// </summary>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult TypeList()
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<CopybookType> types = operater.GetCopybookTypes();
            return Json(types);
        }

        /// <summary>
        /// 字帖的文件列表
        /// </summary>
        /// <param name="id">字帖id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult Detail(string id)
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<Guid> copybook = operater.GetCopybook(id);
            return Json(copybook);
        }
    }
}

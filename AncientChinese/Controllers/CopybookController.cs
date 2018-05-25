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
        public IHttpActionResult CopyBookList()
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<Copybook> copybooks = operater.GetCopybooks();
            return Json(copybooks);
        }
        /// <summary>
        /// 字帖的文件列表
        /// </summary>
        /// <param name="id">字帖id</param>
        /// <returns></returns>
        [HttpGet]
        public IHttpActionResult CopyBook(string id)
        {
            CopybookOperater operater = new CopybookOperater();
            IEnumerable<Guid> copybook = operater.GetCopybook(id);
            return Json(copybook);
        }
    }
}

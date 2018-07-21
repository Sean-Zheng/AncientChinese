using AncientChinese.Models.SqlOperater;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web.Http;

namespace AncientChinese.Controllers
{
    public class FontController : ApiController
    {
        [HttpGet]
        public IHttpActionResult FontType()
        {
            FontOperater operater = new FontOperater();
            var fontTypes=operater.GetFontTypes();
            return Json(fontTypes);
        }
        [HttpGet]
        public IHttpActionResult FontDetail(int typeId)
        {
            FontOperater operater = new FontOperater();
            var fonts = operater.GetFonts(typeId);
            return Json(fonts);
        }
    }
}

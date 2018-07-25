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
            return Json(fonts, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
        }
        [HttpGet]
        public IHttpActionResult FontDetail(string type)
        {
            FontOperater operater = new FontOperater();
            FontType[] types = operater.GetFontTypes().ToArray();
            FontType font = (from item in types where item.TypeName == type select item).FirstOrDefault();
            var fonts = operater.GetFonts(font.TypeId);
            return Json(fonts, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
        }
        [HttpGet]
        public IHttpActionResult Word(string search)
        {
            FontOperater operater = new FontOperater();
            var fonts = operater.GetFonts(search);
            return Json(fonts, new Newtonsoft.Json.JsonSerializerSettings { NullValueHandling = Newtonsoft.Json.NullValueHandling.Ignore });
        }
    }
}

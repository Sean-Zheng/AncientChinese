using AncientChinese.Models.SqlOperater;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http;

namespace AncientChinese.Controllers
{
    public class FileController : ApiController
    {
        [HttpGet]
        public HttpResponseMessage Image(string id)
        {
            FileOperater operater = new FileOperater();
            string fileName = operater.GetFilePath(id);
            if (fileName != null)
            {
                //string path = System.Web.Hosting.HostingEnvironment.MapPath(fileName);
                string path = System.Web.Hosting.HostingEnvironment.MapPath($"~/Resources/{fileName}");
                Stream stream = File.Open(path, FileMode.Open);
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.OK)
                {
                    Content = new StreamContent(stream),
                };
                message.Content.Headers.ContentType = new System.Net.Http.Headers.MediaTypeHeaderValue(MimeMapping.GetMimeMapping(fileName));
                return message;
            }
            else
            {
                HttpResponseMessage message = new HttpResponseMessage(HttpStatusCode.NotFound);
                return message;
            }
        }
    }
}

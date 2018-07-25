using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncientChinese.Models
{
    /// <summary>
    /// 字体
    /// </summary>
    public class Font
    {
        public Guid FileId { get; set; }
        public string Content { get; set; }//字内容
        public string Type { get; set; }
    }
}
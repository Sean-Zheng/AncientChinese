using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace AncientChinese.Models
{
    /// <summary>
    /// 字帖
    /// </summary>
    public class Copybook
    {
        public Guid Id { get; set; }
        public string Title { get; set; }
        public string BookType { get; set; }
    }
}
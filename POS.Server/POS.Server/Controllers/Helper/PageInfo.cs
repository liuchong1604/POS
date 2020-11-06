using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Server.Controllers.Helper
{
    public class PageInfo
    {
        public int PageSize { get; set; }
        public int CurrPage { get; set; }
        public string condition { get; set; }
    }
}
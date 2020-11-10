using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Client1.Controllers.HttpHelper
{
    public class Message<T>
    {
        public int Code { get; set; }
        public bool isSeccess { get; set; }
        public List<T> Data { get; set; }
    }
}
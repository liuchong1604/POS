using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace POS.Server.Controllers.Helper
{
    public class Message<T>
    {
        public int code { get; set; }

        public bool isSuccess { get; set; }

        public List<T> Data { get; set; }
    }
}
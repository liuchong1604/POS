using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Http;
using System.Web;
using System.Web.Http.Filters;

namespace POS.Server.App_Start
{
    public class WebApiExceptionFilterAttribute : ExceptionFilterAttribute
    {
        // 重写基类的异常处理方法
        public override void OnException(HttpActionExecutedContext actionExecutedContext)
        {
            //1. 异常信息记录(正式项目里面一般是使用log4net记录异常日志)
            LogHelper.WriteLog(DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss") + "- -" +
                actionExecutedContext.Exception.GetType().ToString() + ": " + actionExecutedContext.Exception.Message + "--堆栈信息--" +
                actionExecutedContext.Exception.StackTrace);

            //2.返回调用方具体的异常信息
            if(actionExecutedContext.Exception is NotImplementedException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.NotImplemented);
            }
            else if(actionExecutedContext.Exception is TimeoutException)
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.RequestTimeout);
            }
            else
            {
                actionExecutedContext.Response = new HttpResponseMessage(HttpStatusCode.InternalServerError);
            }
            base.OnException(actionExecutedContext);
        }
    }
}

using POS.Server.App_Start;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web.Http;
using System.Web.Http.Cors;

namespace POS.Server
{
    public static class WebApiConfig
    {
        public static void Register(HttpConfiguration config)
        {
            // Web API 配置和服务
            // 解决跨域问题
            config.EnableCors(new EnableCorsAttribute("*","*","*"));
            config.Formatters.Remove(config.Formatters.XmlFormatter);
            // Web API 路由
            config.MapHttpAttributeRoutes();

            config.Routes.MapHttpRoute(
                name: "DefaultApi",
                routeTemplate: "api/{controller}/{id}",
                defaults: new { id = RouteParameter.Optional }
            );

            config.Routes.MapHttpRoute(
                name: "SearchApi",
                routeTemplate: "api/search/{controller}/{name}",
                defaults: new { name = RouteParameter.Optional }
                );
            log4net.Config.XmlConfigurator.Configure(); // 应用程序启动时自动加载配置log4net
            config.Filters.Add(new WebApiExceptionFilterAttribute()); //加载自定义类
        }
    }
}

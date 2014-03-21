using System;
using System.Collections.Generic;
using System.Configuration;
using System.Linq;
using System.Text;
using System.Web.Mvc;
using Autofac;
using Autofac.Core;
using Autofac.Configuration;
using CMSExpress.Common;
using CMSExpress.AppServices.Mvc.Extensions;

namespace CMSExpress.AppServices.Mvc
{
    public class HttpApplicationBase : System.Web.HttpApplication
    {
        public static void RegisterGlobalFilters(GlobalFilterCollection filters)
        {
            filters.Add(new HandleErrorAttribute());
        }

        public static IContainer RegisterAutofacContainer(string configFile = "autofac.config")
        {
            var builder = new ContainerBuilder();
            builder.RegisterModule(new ConfigurationSettingsReader("autofac", configFile));
            return builder.Build();
        }

        protected static void RegisterUnityInstances()
        {
            // 对象注入容器.
            var container = RegisterAutofacContainer();
            ServiceFactory.ResolveHandler = (t) =>
            {
                return container.Resolve(t);
            };
        }

        protected static void RegisterResource(Type resourceType)
        {
            LocalizationExtension.Configure(resourceType);
        }

        protected virtual void Application_Start()
        {
            // 注册 Untiy 服务.
            RegisterUnityInstances();
        }

        protected virtual void Application_Error(object sender, EventArgs e)
        {

        }

        protected virtual void Application_AuthenticateRequest(object sender, EventArgs e)
		{

		}

        protected virtual void Application_AcquireRequestState(object sender, EventArgs e)
        {

        }

        protected virtual void Application_BeginRequest(object sender, EventArgs e)
        {
        }

        protected virtual void Application_End(object sender, EventArgs e)
        {

        }

        protected virtual void Session_Start(object sender, EventArgs e)
        {
        }

        protected virtual void Session_End(object sender, EventArgs e)
        {

        }
    }
}

﻿using AutoMapper;
using MusicBox.App_Start;
using MusicBox.Infrastructure;
using System.Web.Mvc;
using System.Web.Optimization;
using System.Web.Routing;

namespace MusicBox
{
    public class MvcApplication : System.Web.HttpApplication
    {
        protected void Application_Start()
        {
            AreaRegistration.RegisterAllAreas();
            FilterConfig.RegisterGlobalFilters(GlobalFilters.Filters);
            RouteConfig.RegisterRoutes(RouteTable.Routes);
            BundleConfig.RegisterBundles(BundleTable.Bundles);

            AutofacContainer.Register();

            Mapper.Initialize(cfg =>
            {
                AutoMapperConfig.Configure(cfg);
            });

            CreateStorage.CreateUploadedFiles();

            new AddAdminToDb();
        }
    }
}

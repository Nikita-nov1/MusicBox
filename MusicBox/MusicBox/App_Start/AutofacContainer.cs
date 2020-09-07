﻿using Autofac;
using Autofac.Integration.Mvc;
using MusicBox.Data.Context;
using MusicBox.Data.Repositories;
using MusicBox.Data.UnitOfWork;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using MusicBox.PresentationServices.Interfaces;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.Mvc;

namespace MusicBox.App_Start
{
    public static class AutofacContainer
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerRequest();
            builder.RegisterType<MusicBoxDbContext>().As<IMusicBoxDbContext>().InstancePerRequest();

            builder.RegisterAssemblyTypes(typeof(IBasePresentationService).Assembly)
               .Where(t => typeof(IBasePresentationService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IBaseDomainService).Assembly)
               .Where(t => typeof(IBaseDomainService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsClosedTypesOf(typeof(IBaseRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();
            builder.RegisterFilterProvider();

            var container = builder.Build();

            DependencyResolver.SetResolver(new AutofacDependencyResolver(container));
        }
    }
}
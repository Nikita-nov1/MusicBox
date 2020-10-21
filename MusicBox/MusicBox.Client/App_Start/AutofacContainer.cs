using Autofac;
using Autofac.Integration.Mvc;
using FluentValidation;
using FluentValidation.Mvc;
using MusicBox.App_Start.Core;
using MusicBox.Areas.Admin.AdminValidators.Artist;
using MusicBox.Areas.Admin.PresentationServices;
using MusicBox.Areas.Admin.PresentationServices.Interfaces;
using MusicBox.Data.Context;
using MusicBox.Data.Repositories;
using MusicBox.Data.UnitOfWork;
using MusicBox.Domain.DomainServices.Interfaces;
using MusicBox.Domain.Interfaces;
using MusicBox.Domain.Repositories;
using MusicBox.Domain.UnitOfWork;
using MusicBox.PresentationServices.Interfaces;
using System.Linq;
using System.Reflection;
using System.Web.Mvc;

namespace MusicBox.App_Start
{
    public static class AutofacContainer
    {
        public static void Register()
        {
            var builder = new ContainerBuilder();
            builder.RegisterControllers(Assembly.GetExecutingAssembly());

            builder.RegisterType<UnitOfWork>().As<IUnitOfWork>().InstancePerLifetimeScope();
            builder.RegisterType<MusicBoxDbContext>().As<IMusicBoxDbContext>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IBasePresentationService).Assembly)
               .Where(t => typeof(IBasePresentationService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(IBaseAdminPresentationService).Assembly)
               .Where(t => typeof(IBaseAdminPresentationService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterType<GetPathServices>().As<IGetPathServices>().InstancePerLifetimeScope();

            builder.RegisterAssemblyTypes(typeof(IBaseDomainService).Assembly)
               .Where(t => typeof(IBaseDomainService).IsAssignableFrom(t))
               .AsImplementedInterfaces()
               .InstancePerDependency();

            builder.RegisterAssemblyTypes(typeof(BaseRepository<>).Assembly)
                .AsClosedTypesOf(typeof(IBaseRepository<>))
                .AsImplementedInterfaces()
                .InstancePerDependency();

            builder.RegisterFilterProvider();

            AssemblyScanner.FindValidatorsInAssemblyContaining<CreateArtistVmValidator>()
                                  .ForEach(result =>
                                  {
                                      builder.RegisterType(result.ValidatorType)
                                      .AsImplementedInterfaces()
                                      .InstancePerLifetimeScope();
                                  });

            var container = builder.Build();

            var dependencyResolver = new AutofacDependencyResolver(container);

            DependencyResolver.SetResolver(dependencyResolver);

            FluentValidationModelValidatorProvider.Configure(config =>
            {
                config.ValidatorFactory = new AutofacValidatorFactory(dependencyResolver);
            });
        }
    }
}
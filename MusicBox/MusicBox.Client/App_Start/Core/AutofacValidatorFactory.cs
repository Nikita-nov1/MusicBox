using FluentValidation;
using System;
using System.Web.Mvc;

namespace MusicBox.App_Start.Core
{
    public class AutofacValidatorFactory : ValidatorFactoryBase
    {
        private readonly IDependencyResolver dependencyResolver;

        public AutofacValidatorFactory(IDependencyResolver dependencyResolver)
        {
            this.dependencyResolver = dependencyResolver;
        }

        public override IValidator CreateInstance(Type validatorType)
        {
            return dependencyResolver.GetService(validatorType) as IValidator;
        }
    }
}
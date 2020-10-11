using System.Linq;
using System.Reflection;
using AutoMapper;
using System.Collections.Generic;

namespace MusicBox.ExtensionMethods
{
    public static class MappingExpressionExtension
    {
        /// <summary>
        /// Ignore properties in Destination for which there is no match in Source
        /// </summary>
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            var destinationProperties = typeof(TDest).GetProperties().Select<PropertyInfo, string>(s => s.Name);
            var sourceProperties = typeof(TSource).GetProperties().Select<PropertyInfo, string>(s => s.Name);
            var difference = destinationProperties.Except(sourceProperties);
            foreach (var item in difference)
            {
                expression.ForMember(item, o => o.Ignore());
            }

            return expression;
        }

    }
}
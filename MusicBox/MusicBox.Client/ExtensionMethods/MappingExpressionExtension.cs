using System.Linq;
using AutoMapper;

namespace MusicBox.ExtensionMethods
{
    public static class MappingExpressionExtension
    {
        /// <summary>
        /// Ignore properties in Destination for which there is no match in Source.
        /// </summary>
        public static IMappingExpression<TSource, TDest> IgnoreAllUnmapped<TSource, TDest>(this IMappingExpression<TSource, TDest> expression)
        {
            var destinationProperties = typeof(TDest).GetProperties().Select(s => s.Name);
            var sourceProperties = typeof(TSource).GetProperties().Select(s => s.Name);
            var difference = destinationProperties.Except(sourceProperties);
            foreach (var item in difference)
            {
                expression.ForMember(item, o => o.Ignore());
            }

            return expression;
        }
    }
}
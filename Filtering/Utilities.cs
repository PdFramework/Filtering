namespace PeinearyDevelopment.Framework.Filtering
{
  using System;
  using System.Linq.Expressions;
  using System.Reflection;

  internal static class Utilities
  {
    internal static string GetPropertyName<TSource, TProperty>(Type tSourceType, Expression<Func<TSource, TProperty>> propertyLambda) where TSource : class
    {
      var member = propertyLambda.Body as MemberExpression;
      if (member == null)
      {
        member = ((UnaryExpression) propertyLambda.Body).Operand as MemberExpression;
        if(member == null) throw new ArgumentException($"Expression '{propertyLambda}' refers to a method, not a property.");
      }

      var propInfo = member.Member as PropertyInfo;
      if (propInfo == null) throw new ArgumentException($"Expression '{propertyLambda}' refers to a field, not a property.");

      if (!propInfo.ReflectedType.IsAssignableFrom(tSourceType)) throw new ArgumentException($"Expression '{propertyLambda}' refers to a property that is not from type {tSourceType}.");
      //TODO: implement custom attribute to mark properties as not filterable, or alternatively to give them filterable type? id --> int? propInfo.CustomAttributes
      return propInfo.Name;
    }
  }
}

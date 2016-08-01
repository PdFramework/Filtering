namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class StringCriterion<TFilterable> : BaseCriterion<TFilterable, StringFilterType, string> where TFilterable : class, IFilterable
  {
    public StringCriterion()
    {
    }

    public StringCriterion(string propertyName, StringFilterType filterType, string filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public StringCriterion(Expression<Func<TFilterable, string>> propertyNameExpression, StringFilterType filterType, string filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      if (objectPropertyToColumnNameMapper == null) throw new ArgumentNullException(nameof(objectPropertyToColumnNameMapper));

      var columnName = objectPropertyToColumnNameMapper[PropertyName];

      switch (FilterType)
      {
        case StringFilterType.Equals:
          return $"[{columnName}] = @p{parameterIndex}";
        case StringFilterType.DoesNotEqual:
          return $"[{columnName}] != @p{parameterIndex}";
        case StringFilterType.StartsWith:
          return $"[{columnName}] LIKE @p{parameterIndex} + '%'";
        case StringFilterType.EndsWith:
          return $"[{columnName}] LIKE '%' + @p{parameterIndex}";
        case StringFilterType.Contains:
          return $"[{columnName}] LIKE '%' + @p{parameterIndex} + '%'";
        default:
          throw new NotImplementedException();
      }
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      return new[] { new SqlParameter($"p{startingParameterIndex}", FilterValue) };
    }
  }
}

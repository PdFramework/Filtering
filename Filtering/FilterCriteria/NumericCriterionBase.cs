namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  // TODO: look to replace all short, int, long, decimal, float, double types with a more generic numeric type
  public abstract class NumericCriterionBase<TFilterable, TNumeric> : BaseCriterion<TFilterable, NumericFilterType, TNumeric> where TFilterable : class, IFilterable
                                                                                                                              where TNumeric : struct
  {
    protected NumericCriterionBase()
    {
    }

    protected NumericCriterionBase(string propertyName, NumericFilterType filterType, TNumeric filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NumericCriterionBase(Expression<Func<TFilterable, TNumeric>> propertyNameExpression, NumericFilterType filterType, TNumeric filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      if (objectPropertyToColumnNameMapper == null) throw new ArgumentNullException(nameof(objectPropertyToColumnNameMapper));

      var columnName = objectPropertyToColumnNameMapper[PropertyName];

      switch (FilterType)
      {
        case NumericFilterType.LessThan:
          return $"[{columnName}] < @p{parameterIndex}";
        case NumericFilterType.LessThanOrEquals:
          return $"[{columnName}] <= @p{parameterIndex}";
        case NumericFilterType.Equals:
          return $"[{columnName}] = @p{parameterIndex}";
        case NumericFilterType.GreaterThanOrEquals:
          return $"[{columnName}] >= @p{parameterIndex}";
        case NumericFilterType.GreaterThan:
          return $"[{columnName}] > @p{parameterIndex}";
        case NumericFilterType.DoesNotEqual:
          return $"[{columnName}] <> @p{parameterIndex}";
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

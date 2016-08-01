namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class NullableDateTimeCriterionBase<TFilterable, TDateTime> : BaseCriterion<TFilterable, DateTimeFilterType, TDateTime> where TFilterable : class, IFilterable
  {
    protected NullableDateTimeCriterionBase()
    {
    }

    protected NullableDateTimeCriterionBase(string propertyName, DateTimeFilterType filterType, TDateTime filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NullableDateTimeCriterionBase(Expression<Func<TFilterable, TDateTime>> propertyNameExpression, DateTimeFilterType filterType, TDateTime filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      if (objectPropertyToColumnNameMapper == null) throw new ArgumentNullException(nameof(objectPropertyToColumnNameMapper));

      var columnName = objectPropertyToColumnNameMapper[PropertyName];

      switch (FilterType)
      {
        case DateTimeFilterType.Before:
          return $"[{columnName}] < @p{parameterIndex}";
        case DateTimeFilterType.BeforeOrEquals:
          return $"[{columnName}] <= @p{parameterIndex}";
        case DateTimeFilterType.Equals:
          return $"[{columnName}] = @p{parameterIndex}";
        case DateTimeFilterType.AfterOrEquals:
          return $"[{columnName}] >= @p{parameterIndex}";
        case DateTimeFilterType.After:
          return $"[{columnName}] > @p{parameterIndex}";
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

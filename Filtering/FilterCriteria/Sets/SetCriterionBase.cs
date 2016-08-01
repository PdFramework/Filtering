namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq;
  using System.Linq.Expressions;

  public abstract class SetCriterionBase<TFilterable, TFilterableProperty> : BaseCriterion<TFilterable, TFilterableProperty, SetFilterType, IEnumerable<TFilterableProperty>> where TFilterable : class, IFilterable
  {
    protected SetCriterionBase()
    {
    }

    protected SetCriterionBase(string propertyName, SetFilterType filterType, IEnumerable<TFilterableProperty> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected SetCriterionBase(Expression<Func<TFilterable, TFilterableProperty>> propertyNameExpression, SetFilterType filterType, IEnumerable<TFilterableProperty> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      if (objectPropertyToColumnNameMapper == null) throw new ArgumentNullException(nameof(objectPropertyToColumnNameMapper));
      if (FilterType == SetFilterType.Between && FilterValue.Count() != 2) throw new ArgumentOutOfRangeException(nameof(objectPropertyToColumnNameMapper), "The 'Between' search type may only be used with exactly 2 values.");

      var columnName = objectPropertyToColumnNameMapper[PropertyName];
      var parametersString = FilterType == SetFilterType.Between ? $"@p{parameterIndex++} AND @p{parameterIndex++}" : string.Join(", ", FilterValue.Select(value => $"@p{parameterIndex++}"));

      switch (FilterType)
      {
        case SetFilterType.In:
          return $"[{columnName}] IN ({parametersString})";
        case SetFilterType.Between:
          return $"[{columnName}] BETWEEN {parametersString}";
        case SetFilterType.NotIn:
          return $"[{columnName}] NOT IN @p{parameterIndex}";
        default:
          throw new NotImplementedException();
      }
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      return FilterValue.Select(value => new SqlParameter($"p{startingParameterIndex++}", value));
    }
  }
}

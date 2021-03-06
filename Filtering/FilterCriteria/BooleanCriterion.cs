﻿namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class BooleanCriterion<TFilterable> : BaseCriterion<TFilterable, BooleanFilterType, bool> where TFilterable : class, IFilterable
  {
    public BooleanCriterion()
    {
    }

    public BooleanCriterion(string propertyName, BooleanFilterType filterType, bool filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public BooleanCriterion(Expression<Func<TFilterable, bool>> propertyNameExpression, BooleanFilterType filterType, bool filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      if(objectPropertyToColumnNameMapper == null) throw new ArgumentNullException(nameof(objectPropertyToColumnNameMapper));

      var columnName = objectPropertyToColumnNameMapper[PropertyName];

      switch (FilterType)
      {
        case BooleanFilterType.Equals:
          return string.Format($"[{columnName}] = @p{parameterIndex}");
        case BooleanFilterType.DoesNotEqual:
          return $"[{columnName}] <> @p{parameterIndex}";
        default:
          throw new NotImplementedException();
      }
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      return new[] {new SqlParameter($"p{startingParameterIndex}", FilterValue)};
    }
  }
}

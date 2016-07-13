namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDecimalSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, decimal?> where TFilterable : class, IFilterable
  {
    public NullableDecimalSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<decimal?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDecimalSetCriterion(Expression<Func<TFilterable, decimal?>> propertyNameExpression, SetFilterType filterType, IEnumerable<decimal?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

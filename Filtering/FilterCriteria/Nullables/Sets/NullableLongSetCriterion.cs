namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableLongSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, long?> where TFilterable : class, IFilterable
  {
    public NullableLongSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<long?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableLongSetCriterion(Expression<Func<TFilterable, long?>> propertyNameExpression, SetFilterType filterType, IEnumerable<long?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableShortSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, short?> where TFilterable : class, IFilterable
  {
    public NullableShortSetCriterion()
    {
    }

    public NullableShortSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<short?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableShortSetCriterion(Expression<Func<TFilterable, short?>> propertyNameExpression, SetFilterType filterType, IEnumerable<short?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

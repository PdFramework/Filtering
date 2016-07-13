namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableFloatSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, float?> where TFilterable : class, IFilterable
  {
    public NullableFloatSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<float?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableFloatSetCriterion(Expression<Func<TFilterable, float?>> propertyNameExpression, SetFilterType filterType, IEnumerable<float?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

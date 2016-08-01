namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDoubleSetCriterion<TFilterable> : NullableSetCriterionBase<TFilterable, double?> where TFilterable : class, IFilterable
  {
    public NullableDoubleSetCriterion()
    {
    }

    public NullableDoubleSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDoubleSetCriterion(Expression<Func<TFilterable, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

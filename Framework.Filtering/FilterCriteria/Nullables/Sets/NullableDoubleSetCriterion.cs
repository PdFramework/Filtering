namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class NullableDoubleSetCriterion<TFilterableObject> : NullableNumericSetCriterionBase<TFilterableObject, double?> where TFilterableObject : class, IFilterable
  {
    public NullableDoubleSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<double?> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDoubleSetCriterion(Expression<Func<TFilterableObject, double?>> propertyNameExpression, SetFilterType filterType, IEnumerable<double?> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class LongSetCriterion<TFilterableObject> : NumericSetCriterionBase<TFilterableObject, long> where TFilterableObject : class, IFilterable
  {
    public LongSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<long> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public LongSetCriterion(Expression<Func<TFilterableObject, long>> propertyNameExpression, SetFilterType filterType, IEnumerable<long> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

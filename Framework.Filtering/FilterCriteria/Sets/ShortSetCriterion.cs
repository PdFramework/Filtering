namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class ShortSetCriterion<TFilterableObject> : NumericSetCriterionBase<TFilterableObject, short> where TFilterableObject : class, IFilterable
  {
    public ShortSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<short> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public ShortSetCriterion(Expression<Func<TFilterableObject, short>> propertyNameExpression, SetFilterType filterType, IEnumerable<short> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

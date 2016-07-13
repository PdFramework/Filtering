namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class ShortSetCriterion<TFilterable> : SetCriterionBase<TFilterable, short> where TFilterable : class, IFilterable
  {
    public ShortSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<short> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public ShortSetCriterion(Expression<Func<TFilterable, short>> propertyNameExpression, SetFilterType filterType, IEnumerable<short> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

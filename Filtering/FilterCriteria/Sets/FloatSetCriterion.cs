namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class FloatSetCriterion<TFilterable> : SetCriterionBase<TFilterable, float> where TFilterable : class, IFilterable
  {
    public FloatSetCriterion()
    {
    }

    public FloatSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<float> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public FloatSetCriterion(Expression<Func<TFilterable, float>> propertyNameExpression, SetFilterType filterType, IEnumerable<float> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

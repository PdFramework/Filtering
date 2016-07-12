namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Linq.Expressions;

  public class FloatSetCriterion<TFilterableObject> : NumericSetCriterionBase<TFilterableObject, float> where TFilterableObject : class, IFilterable
  {
    public FloatSetCriterion(string propertyName, SetFilterType filterType, IEnumerable<float> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public FloatSetCriterion(Expression<Func<TFilterableObject, float>> propertyNameExpression, SetFilterType filterType, IEnumerable<float> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

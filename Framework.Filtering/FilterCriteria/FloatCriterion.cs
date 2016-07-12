namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class FloatCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, float> where TFilterableObject : class, IFilterable
  {
    public FloatCriterion(string propertyName, NumericFilterType filterType, float filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public FloatCriterion(Expression<Func<TFilterableObject, float>> propertyNameExpression, NumericFilterType filterType, float filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

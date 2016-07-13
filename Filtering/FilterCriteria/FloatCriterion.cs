namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class FloatCriterion<TFilterable> : NumericCriterionBase<TFilterable, float> where TFilterable : class, IFilterable
  {
    public FloatCriterion(string propertyName, NumericFilterType filterType, float filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public FloatCriterion(Expression<Func<TFilterable, float>> propertyNameExpression, NumericFilterType filterType, float filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

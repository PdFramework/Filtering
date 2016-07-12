namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class LongCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, long> where TFilterableObject : class, IFilterable
  {
    public LongCriterion(string propertyName, NumericFilterType filterType, long filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public LongCriterion(Expression<Func<TFilterableObject, long>> propertyNameExpression, NumericFilterType filterType, long filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

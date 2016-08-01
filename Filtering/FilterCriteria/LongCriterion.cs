namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class LongCriterion<TFilterable> : NumericCriterionBase<TFilterable, long> where TFilterable : class, IFilterable
  {
    public LongCriterion()
    {
    }

    public LongCriterion(string propertyName, NumericFilterType filterType, long filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public LongCriterion(Expression<Func<TFilterable, long>> propertyNameExpression, NumericFilterType filterType, long filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

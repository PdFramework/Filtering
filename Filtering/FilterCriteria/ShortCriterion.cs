namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class ShortCriterion<TFilterable> : NumericCriterionBase<TFilterable, short> where TFilterable : class, IFilterable
  {
    public ShortCriterion(string propertyName, NumericFilterType filterType, short filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public ShortCriterion(Expression<Func<TFilterable, short>> propertyNameExpression, NumericFilterType filterType, short filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

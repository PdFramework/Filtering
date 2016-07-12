namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class ShortCriterion<TFilterableObject> : NumericCriterionBase<TFilterableObject, short> where TFilterableObject : class, IFilterable
  {
    public ShortCriterion(string propertyName, NumericFilterType filterType, short filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public ShortCriterion(Expression<Func<TFilterableObject, short>> propertyNameExpression, NumericFilterType filterType, short filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

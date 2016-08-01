namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DateTimeCriterion<TFilterable> : DateTimeCriterionBase<TFilterable, DateTime> where TFilterable : class, IFilterable
  {
    public DateTimeCriterion()
    {
    }

    public DateTimeCriterion(string propertyName, DateTimeFilterType filterType, DateTime filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeCriterion(Expression<Func<TFilterable, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

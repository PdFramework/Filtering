namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class DateTimeCriterion<TFilterableObject> : DateTimeCriterionBase<TFilterableObject, DateTime> where TFilterableObject : class, IFilterable
  {
    public DateTimeCriterion(string propertyName, DateTimeFilterType filterType, DateTime filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeCriterion(Expression<Func<TFilterableObject, DateTime>> propertyNameExpression, DateTimeFilterType filterType, DateTime filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

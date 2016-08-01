namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDateTimeCriterion<TFilterable> : NullableDateTimeCriterionBase<TFilterable, DateTime?> where TFilterable : class, IFilterable
  {
    public NullableDateTimeCriterion()
    {
    }

    public NullableDateTimeCriterion(string propertyName, DateTimeFilterType filterType, DateTime? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeCriterion(Expression<Func<TFilterable, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

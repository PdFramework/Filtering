namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableDateTimeCriterion<TFilterableObject> : NullableDateTimeCriterionBase<TFilterableObject, DateTime?> where TFilterableObject : class, IFilterable
  {
    public NullableDateTimeCriterion(string propertyName, DateTimeFilterType filterType, DateTime? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableDateTimeCriterion(Expression<Func<TFilterableObject, DateTime?>> propertyNameExpression, DateTimeFilterType filterType, DateTime? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

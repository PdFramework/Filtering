namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableLongCriterion<TFilterableObject> : NullableNumericCriterionBase<TFilterableObject, long?> where TFilterableObject : class, IFilterable
  {
    public NullableLongCriterion(string propertyName, NumericFilterType filterType, long? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableLongCriterion(Expression<Func<TFilterableObject, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

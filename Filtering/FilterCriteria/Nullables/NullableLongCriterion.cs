namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableLongCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, long?> where TFilterable : class, IFilterable
  {
    public NullableLongCriterion(string propertyName, NumericFilterType filterType, long? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableLongCriterion(Expression<Func<TFilterable, long?>> propertyNameExpression, NumericFilterType filterType, long? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

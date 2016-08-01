namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableShortCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, short?> where TFilterable : class, IFilterable
  {
    public NullableShortCriterion()
    {
    }

    public NullableShortCriterion(string propertyName, NumericFilterType filterType, short? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableShortCriterion(Expression<Func<TFilterable, short?>> propertyNameExpression, NumericFilterType filterType, short? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

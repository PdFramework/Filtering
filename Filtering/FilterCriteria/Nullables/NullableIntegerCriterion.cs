namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables
{
  using FilterTypes;

  using System;
  using System.Linq.Expressions;

  public class NullableIntegerCriterion<TFilterable> : NullableNumericCriterionBase<TFilterable, int?> where TFilterable : class, IFilterable
  {
    public NullableIntegerCriterion(string propertyName, NumericFilterType filterType, int? filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public NullableIntegerCriterion(Expression<Func<TFilterable, int?>> propertyNameExpression, NumericFilterType filterType, int? filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }
  }
}

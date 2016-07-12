namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class DateTimeSetCriterionBase<TFilterableObject, TDateTime> : SetCriterionBase<TFilterableObject, TDateTime> where TFilterableObject : class, IFilterable
  {
    public DateTimeSetCriterionBase(string propertyName, SetFilterType filterType, IEnumerable<TDateTime> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public DateTimeSetCriterionBase(Expression<Func<TFilterableObject, TDateTime>> propertyNameExpression, SetFilterType filterType, IEnumerable<TDateTime> filterValue) : base(propertyNameExpression, filterType, filterValue)
    {
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      throw new System.NotImplementedException();
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      throw new System.NotImplementedException();
    }
  }
}

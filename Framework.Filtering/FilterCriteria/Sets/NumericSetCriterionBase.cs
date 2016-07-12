namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class NumericSetCriterionBase<TFilterableObject, TNumeric> : SetCriterionBase<TFilterableObject, TNumeric> where TFilterableObject : class, IFilterable
  {
    protected NumericSetCriterionBase(string propertyName, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NumericSetCriterionBase(Expression<Func<TFilterableObject, TNumeric>> propertyNameExpression, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyNameExpression, filterType, filterValue)
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

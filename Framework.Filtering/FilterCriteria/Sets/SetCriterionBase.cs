namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public class SetCriterionBase<TFilterableObject, TFilterableObjectProperty> : BaseCriterion<TFilterableObject, TFilterableObjectProperty, SetFilterType, IEnumerable<TFilterableObjectProperty>> where TFilterableObject : class, IFilterable
  {
    public SetCriterionBase(string propertyName, SetFilterType filterType, IEnumerable<TFilterableObjectProperty> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    public SetCriterionBase(Expression<Func<TFilterableObject, TFilterableObjectProperty>> propertyNameExpression, SetFilterType filterType, IEnumerable<TFilterableObjectProperty> filterValue) : base(propertyNameExpression, filterType, filterValue)
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

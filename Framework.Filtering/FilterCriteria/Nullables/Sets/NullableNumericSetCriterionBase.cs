using System;
using System.Collections.Generic;
using System.Data.SqlClient;
using System.Linq.Expressions;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria.Sets;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria.Nullables.Sets
{
  public abstract class NullableNumericSetCriterionBase<TFilterableObject, TNumeric> : SetCriterionBase<TFilterableObject, TNumeric> where TFilterableObject : class, IFilterable
  {
    protected NullableNumericSetCriterionBase(string propertyName, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyName, filterType, filterValue)
    {
    }

    protected NullableNumericSetCriterionBase(Expression<Func<TFilterableObject, TNumeric>> propertyNameExpression, SetFilterType filterType, IEnumerable<TNumeric> filterValue) : base(propertyNameExpression, filterType, filterValue)
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

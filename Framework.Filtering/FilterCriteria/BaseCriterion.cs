namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;
  using System.Linq.Expressions;

  public abstract class BaseCriterion
  {
    internal abstract string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex);
    //TODO: investigate using IEnumerable<DbParameter> as type
    internal abstract IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex);
    internal string PropertyName { get; set; }
    public object FilterType { get; set; }
    public object FilterValue { get; set; }
  }

  public class BaseCriterion<TFilterableObject, TFilterType, TFilterValue> : BaseCriterion where TFilterableObject : class, IFilterable
  {
    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      throw new NotImplementedException();
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      throw new NotImplementedException();
    }

    public new TFilterType FilterType { get; set; }
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }

    protected BaseCriterion(Expression<Func<TFilterableObject, TFilterValue>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue)
      : this(Utilities.GetPropertyName(typeof(TFilterableObject), propertyNameExpression), filterType, filterValue)
    {
    }
  }

  public class BaseCriterion<TFilterableObject, TFilterableObjectProperty, TFilterType, TFilterValue> : BaseCriterion where TFilterableObject : class, IFilterable
                                                                                                                      where TFilterValue : IEnumerable<TFilterableObjectProperty>
  {
    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      throw new NotImplementedException();
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      throw new NotImplementedException();
    }

    public new TFilterType FilterType { get; set; }
    public new TFilterValue FilterValue { get; set; }

    public BaseCriterion(string propertyName, TFilterType filterType, TFilterValue filterValue)
    {
      PropertyName = propertyName;
      FilterType = filterType;
      FilterValue = filterValue;
    }

    protected BaseCriterion(Expression<Func<TFilterableObject, TFilterableObjectProperty>> propertyNameExpression, TFilterType filterType, TFilterValue filterValue)
      : this(Utilities.GetPropertyName(typeof(TFilterableObject), propertyNameExpression), filterType, filterValue)
    {
    }
  }
}

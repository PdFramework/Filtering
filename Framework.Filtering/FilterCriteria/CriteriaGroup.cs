namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;

  public class CriteriaGroup : BaseCriterion
  {
    public IList<BaseCriterion> Criteria { get; set; }
    public IList<CompoundFilterType> CompoundFilterTypes { get; set; }

    public CriteriaGroup()
    {
      Criteria = new List<BaseCriterion>();
      CompoundFilterTypes = new List<CompoundFilterType>();
    }

    public CriteriaGroup(BaseCriterion baseCriterion)
    {
      Criteria = new List<BaseCriterion> { baseCriterion };
      CompoundFilterTypes = new List<CompoundFilterType>();
    }

    public CriteriaGroup(IList<BaseCriterion> criteria, IList<CompoundFilterType> compoundFilterTypes)
    {
      if(criteria == null) throw new ArgumentNullException(nameof(criteria));
      if(compoundFilterTypes == null) throw new ArgumentNullException(nameof(compoundFilterTypes));
      if(compoundFilterTypes.Count + 1 != criteria.Count) throw new ArgumentException("There must be exactly one less compound filter type than number of criterion. i.e. criterion AND criterion");
      Criteria = criteria;
      CompoundFilterTypes = compoundFilterTypes;
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

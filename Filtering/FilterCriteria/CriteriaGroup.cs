﻿namespace PeinearyDevelopment.Framework.Filtering.FilterCriteria
{
  using FilterTypes;

  using Newtonsoft.Json;
  using System;
  using System.Collections.Generic;
  using System.Data.SqlClient;

  public class CriteriaGroup : BaseCriterion
  {
    [JsonProperty(ItemTypeNameHandling = TypeNameHandling.Auto)]
    public IList<BaseCriterion> Criteria { get; }
    public IList<CompoundFilterType> CompoundFilterTypes { get; }

    public CriteriaGroup() : this(new List<BaseCriterion>(), new List<CompoundFilterType>())
    {
    }

    public CriteriaGroup(BaseCriterion baseCriterion) : this(new List<BaseCriterion> { baseCriterion }, new List<CompoundFilterType>())
    {
    }

    public CriteriaGroup(IList<BaseCriterion> criteria, IList<CompoundFilterType> compoundFilterTypes)
    {
      if(criteria == null) throw new ArgumentNullException(nameof(criteria));
      if(compoundFilterTypes == null) throw new ArgumentNullException(nameof(compoundFilterTypes));
      if(compoundFilterTypes.Count > 1 && compoundFilterTypes.Count + 1 != criteria.Count) throw new ArgumentException("There must be exactly one less compound filter type than number of criterion. i.e. criterion AND criterion");

      Criteria = criteria;
      CompoundFilterTypes = compoundFilterTypes;
    }

    internal override string CreateWhere(IDictionary<string, string> objectPropertyToColumnNameMapper, int parameterIndex)
    {
      throw new NotImplementedException($"The library is unaware of how to turn a {typeof(CriteriaGroup)} object into a where clause.");
    }

    internal override IEnumerable<SqlParameter> CreateParameters(int startingParameterIndex)
    {
      throw new NotImplementedException();
    }
  }
}

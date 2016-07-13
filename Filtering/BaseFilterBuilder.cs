using System;
using System.Collections.Generic;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace PeinearyDevelopment.Framework.Filtering
{
  public abstract class BaseFilterBuilder
  {
    public IList<SortCriterion> SortCriteria { get; }
    public IList<CriteriaGroup> FilterCriteria { get; }
    public IList<CompoundFilterType> FilterCombiners { get; }

    public int PageIndex { get; set; }
    public int PageSize { get; set; }
    public bool ReturnAllResults { get; set; }
    public bool IncludeTotalCountWithResults { get; set; }

    protected BaseFilterBuilder()
    {
      SortCriteria = new List<SortCriterion>();
      FilterCriteria = new List<CriteriaGroup>();
      //FilterGroupers?Linkers?Joiners?Combiners?Compounders?
      FilterCombiners = new List<CompoundFilterType>();
      PageIndex = 0;
      PageSize = 10;
    }

    protected BaseFilterBuilder(BaseFilterBuilder baseFilterBuilder)
    {
      if (baseFilterBuilder == null) throw new ArgumentNullException(nameof(baseFilterBuilder));

      FilterCombiners = baseFilterBuilder.FilterCombiners;
      FilterCriteria = baseFilterBuilder.FilterCriteria;
      IncludeTotalCountWithResults = baseFilterBuilder.IncludeTotalCountWithResults;
      PageIndex = baseFilterBuilder.PageIndex;
      PageSize = baseFilterBuilder.PageSize;
      ReturnAllResults = baseFilterBuilder.ReturnAllResults;
      SortCriteria = baseFilterBuilder.SortCriteria;
    }
  }

  public abstract class BaseFilterBuilder<TFilterable> : BaseFilterBuilder where TFilterable : class, IFilterable
  {
    internal Type FilterableObjectType { get; set; }


    protected BaseFilterBuilder()
    {
      FilterableObjectType = typeof(TFilterable);
    }

    protected BaseFilterBuilder(BaseFilterBuilder baseFilterBuilder) : base(baseFilterBuilder)
    {
      FilterableObjectType = typeof(TFilterable);
    }

    protected BaseFilterBuilder(BaseFilterBuilder<TFilterable> baseFilterBuilder) : base(baseFilterBuilder)
    {
      FilterableObjectType = baseFilterBuilder.FilterableObjectType;
    }
  }
}

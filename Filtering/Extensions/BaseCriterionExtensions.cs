using System.Collections.Generic;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace PeinearyDevelopment.Framework.Filtering.Extensions
{
  public static class BaseCriterionExtensions
  {
    public static CriteriaGroup And(this BaseCriterion baseCriterion, BaseCriterion criterion)
    {
      if (baseCriterion == null)
      {
        return new CriteriaGroup(criterion);
      }

      var criteriaGroup = baseCriterion as CriteriaGroup;
      if (criteriaGroup == null)
      {
        return new CriteriaGroup(new[] { baseCriterion, criterion }, new List<CompoundFilterType> { CompoundFilterType.And });
      }

      criteriaGroup.Criteria.Add(criterion);
      criteriaGroup.CompoundFilterTypes.Add(CompoundFilterType.And);
      return criteriaGroup;
    }

    public static CriteriaGroup Or(this BaseCriterion baseCriterion, BaseCriterion criterion)
    {
      if (baseCriterion == null)
      {
        return new CriteriaGroup(criterion);
      }

      var criteriaGroup = baseCriterion as CriteriaGroup;
      if (criteriaGroup == null)
      {
        return new CriteriaGroup(new[] { baseCriterion, criterion }, new List<CompoundFilterType> { CompoundFilterType.Or });
      }

      criteriaGroup.Criteria.Add(criterion);
      criteriaGroup.CompoundFilterTypes.Add(CompoundFilterType.Or);
      return criteriaGroup;
    }
  }
}

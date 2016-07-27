namespace PeinearyDevelopment.Framework.Filtering.Extensions
{
  using FilterCriteria;
  using FilterTypes;

  using System.Collections.Generic;
  using System.Linq;

  public static class BaseCriterionExtensions
  {
    public static BaseCriterion And(this BaseCriterion baseCriterion, BaseCriterion criterion)
    {
      if (baseCriterion == null)
      {
        return criterion;
      }

      var criteriaGroup = baseCriterion as CriteriaGroup;
      if (criteriaGroup == null)
      {
        return new CriteriaGroup(new[] { baseCriterion, criterion }.ToList(), new List<CompoundFilterType> { CompoundFilterType.And });
      }

      criteriaGroup.Criteria.Add(criterion);
      criteriaGroup.CompoundFilterTypes.Add(CompoundFilterType.And);
      return criteriaGroup;
    }

    public static BaseCriterion Or(this BaseCriterion baseCriterion, BaseCriterion criterion)
    {
      if (baseCriterion == null)
      {
        return criterion;
      }

      var criteriaGroup = baseCriterion as CriteriaGroup;
      if (criteriaGroup == null)
      {
        return new CriteriaGroup(new[] { baseCriterion, criterion }.ToList(), new List<CompoundFilterType> { CompoundFilterType.Or });
      }

      criteriaGroup.Criteria.Add(criterion);
      criteriaGroup.CompoundFilterTypes.Add(CompoundFilterType.Or);
      return criteriaGroup;
    }
  }
}

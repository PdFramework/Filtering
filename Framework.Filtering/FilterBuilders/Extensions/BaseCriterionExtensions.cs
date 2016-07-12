﻿namespace PeinearyDevelopment.Framework.Filtering.FilterBuilders.Extensions
{
  using FilterCriteria;
  using FilterTypes;

  using System.Collections.Generic;

  public static class BaseCriterionExtensions
  {
    public static CriteriaGroup And(this BaseCriterion baseCriterion, BaseCriterion criterion)
    {
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
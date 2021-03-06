﻿namespace PeinearyDevelopment.Framework.Filtering.Data.Entity
{
  using FilterCriteria;

  using System.Data.Entity.Infrastructure;
  using System.Globalization;
  using System.Linq;
  using System.Threading.Tasks;

  internal static class FilterExtensions
  {
    internal static int? GetTotalNumberOfResults<TFilterable>(this Filter<TFilterable> filter, BaseFilterBuilder<TFilterable> filterBuilder, IObjectContextAdapter dbContext) where TFilterable : class, IFilterable
    {
      if (!filterBuilder.IncludeTotalCountWithResults || filterBuilder.Skip != 0) return null;

      var countQueryBuilder = new Filter<TFilterable>(filter.DbObjectMapper).CreateCountQueryBuilder(dbContext, filterBuilder);
      return dbContext.ObjectContext.ExecuteStoreQuery<int>(countQueryBuilder.SqlQueryStringBuilder.ToString(), countQueryBuilder.Parameters.ToArray()).First();
    }

    internal static async Task<int?> GetTotalNumberOfResultsAsync<TFilterable>(this Filter<TFilterable> filter, BaseFilterBuilder<TFilterable> filterBuilder, IObjectContextAdapter dbContext) where TFilterable : class, IFilterable
    {
      if (!filterBuilder.IncludeTotalCountWithResults || filterBuilder.Skip != 0) return null;

      var countQueryBuilder = new Filter<TFilterable>(filter.DbObjectMapper).CreateCountQueryBuilder(dbContext, filterBuilder);

      return (await dbContext.ObjectContext.ExecuteStoreQueryAsync<int>(countQueryBuilder.SqlQueryStringBuilder.ToString(), countQueryBuilder.Parameters.ToArray())).First();
    }

    internal static Filter<TFilterable> CreateCountQueryBuilder<TFilterable>(this Filter<TFilterable> filter, IObjectContextAdapter dbContext, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      filter.CreateCountSelect()
            .CreateFrom()
            .CreateWhere(dbContext, filterBuilder);

      return filter;
    }

    internal static Filter<TFilterable> CreateSelect<TFilterable>(this Filter<TFilterable> filter) where TFilterable : class, IFilterable
    {
      var sqlProperties = string.Join(", ", filter.DbObjectMapper.ObjectPropertyColumnNameMapper.Select(propertyToColumnNameMap => $"[{propertyToColumnNameMap.Value}] AS [{propertyToColumnNameMap.Key}]"));
      filter.SqlQueryStringBuilder
            .SafeSqlAppend("SELECT")
            .SafeSqlAppend(sqlProperties);
      return filter;
    }

    internal static Filter<TFilterable> CreateCountSelect<TFilterable>(this Filter<TFilterable> filter) where TFilterable : class, IFilterable
    {
      filter.SqlQueryStringBuilder
            .SafeSqlAppend("SELECT COUNT(1)");
      return filter;
    }

    internal static Filter<TFilterable> CreateFrom<TFilterable>(this Filter<TFilterable> filter) where TFilterable : class, IFilterable
    {
      filter.SqlQueryStringBuilder
            .SafeSqlAppend("FROM")
            .SafeSqlAppend($"[{filter.DbObjectMapper.DbSchema}].[{filter.DbObjectMapper.DbTableName}]");
      return filter;
    }

    internal static Filter<TFilterable> CreatePaginationFrom<TFilterable>(this Filter<TFilterable> filter, IObjectContextAdapter dbContext, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
        filter.SqlQueryStringBuilder
                .SafeSqlAppend("FROM (");
        filter.CreateSelect();
        filter.SqlQueryStringBuilder
              .Append(",")
              .SafeSqlAppend("ROW_NUMBER() OVER(");
        filter.CreateOrderBy(filterBuilder);
        filter.SqlQueryStringBuilder
              .SafeSqlAppend(") AS [row_num]");
        filter.CreateFrom()
              .CreateWhere(dbContext, filterBuilder);
        filter.SqlQueryStringBuilder
              .SafeSqlAppend(") as T")
              .SafeSqlAppend($"WHERE [row_num] BETWEEN {filterBuilder.Skip + 1} AND {filterBuilder.Skip + filterBuilder.Take + 1}");

        return filter;
    }

    internal static Filter<TFilterable> CreateOrderBy<TFilterable>(this Filter<TFilterable> filter, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      filter.SqlQueryStringBuilder
            .SafeSqlAppend("ORDER BY");

      if (filterBuilder.SortCriteria.Any())
      {
        foreach (var sortCriteria in filterBuilder.SortCriteria)
        {
          var sortDirectionString = sortCriteria.SortType == SortType.Ascending ? "ASC" : "DESC";

          filter.SqlQueryStringBuilder
                .SafeSqlAppend($"[{filter.DbObjectMapper.ObjectPropertyColumnNameMapper[sortCriteria.SortPropertyName]}] {sortDirectionString}");

          if (filterBuilder.SortCriteria.Count > 1 && filterBuilder.SortCriteria.Last() != sortCriteria)
          {
            filter.SqlQueryStringBuilder.Append(",");
          }
        }
      }
      else
      {
        filter.SqlQueryStringBuilder
              .SafeSqlAppend($"[{filter.DbObjectMapper.PrimaryKeyPropertyName}]");
      }

      return filter;
    }

    internal static Filter<TFilterable> CreateOffset<TFilterable>(this Filter<TFilterable> filter, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      if (!filterBuilder.ReturnAllResults)
      {
        filter.SqlQueryStringBuilder
              .SafeSqlAppend($"OFFSET {filterBuilder.Skip} ROWS FETCH NEXT {filterBuilder.Take + 1} ROWS ONLY");
      }

      return filter;
    }

    internal static Filter<TFilterable> CreateWhere<TFilterable>(this Filter<TFilterable> filter, IObjectContextAdapter dbContext, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      var tmpQueryBuilder = new Filter<TFilterable>(dbContext.MapDbProperties<TFilterable>()).BuildWhere(filterBuilder);

      if (tmpQueryBuilder.SqlQueryStringBuilder.Length > 0)
      {
        filter.SqlQueryStringBuilder
              .SafeSqlAppend("WHERE")
              .SafeSqlAppend(tmpQueryBuilder.SqlQueryStringBuilder);

        filter.Parameters = tmpQueryBuilder.Parameters;
      }
      return filter;
    }

    internal static Filter<TFilterable> BuildWhere<TFilterable>(this Filter<TFilterable> filter, BaseFilterBuilder<TFilterable> filterBuilder) where TFilterable : class, IFilterable
    {
      //TODO: char, byte
      if (filterBuilder.FilterCriteria.CompoundFilterTypes.Any())
      {
        filter.SqlQueryStringBuilder.SafeSqlAppend("(");

        for (var i = 0; i < filterBuilder.FilterCriteria.Criteria.Count; i++)
        {
          if (i != 0)
          {
            filter.SqlQueryStringBuilder.SafeSqlAppend(filterBuilder.FilterCriteria.CompoundFilterTypes[i - 1].ToString().ToUpper(CultureInfo.InvariantCulture));
          }

          filter.BuildWhere(filterBuilder.FilterCriteria.Criteria[i]);
        }

        filter.SqlQueryStringBuilder.SafeSqlAppend(")");
      }
      else if(filterBuilder.FilterCriteria.Criteria.Any())
      {
        filter.BuildWhere(filterBuilder.FilterCriteria.Criteria[0]);
      }

      return filter;
    }

    internal static Filter<TFilterable> BuildWhere<TFilterable>(this Filter<TFilterable> filter, CriteriaGroup criteriaGroup) where TFilterable : class, IFilterable
    {
      if (criteriaGroup.CompoundFilterTypes.Any())
      {
        filter.SqlQueryStringBuilder.SafeSqlAppend("(");

        for (var i = 0; i < criteriaGroup.Criteria.Count; i++)
        {
          if (i != 0)
          {
            filter.SqlQueryStringBuilder.SafeSqlAppend(criteriaGroup.CompoundFilterTypes[i - 1].ToString().ToUpper(CultureInfo.InvariantCulture));
          }

          var nestedCriteriaGroup = criteriaGroup.Criteria[i] as CriteriaGroup;
          if (nestedCriteriaGroup != null)
          {
            filter.BuildWhere(nestedCriteriaGroup);
          }
          else
          {
            filter.BuildWhere(criteriaGroup.Criteria[i]);
          }
        }

        filter.SqlQueryStringBuilder.SafeSqlAppend(")");
      }
      else if(criteriaGroup.Criteria.Any())
      {
        var nestedCriteriaGroup = criteriaGroup.Criteria[0] as CriteriaGroup;
        if (nestedCriteriaGroup != null)
        {
          filter.BuildWhere(nestedCriteriaGroup);
        }
        else 
        {
          filter.BuildWhere(criteriaGroup.Criteria[0]);
        }
      }

      return filter;
    }

    internal static Filter<TFilterable> BuildWhere<TFilterable>(this Filter<TFilterable> filter, BaseCriterion baseCriterion) where TFilterable : class, IFilterable
    {
      var criteriaGroup = baseCriterion as CriteriaGroup;
      if (criteriaGroup != null)
      {
        filter.BuildWhere(criteriaGroup);
      }
      else
      {
        var whereClause = baseCriterion.CreateWhere(filter.DbObjectMapper.ObjectPropertyColumnNameMapper, filter.Parameters.Count);

        if (!string.IsNullOrWhiteSpace(whereClause))
        {
          var @params = baseCriterion.CreateParameters(filter.Parameters.Count);

          filter.SqlQueryStringBuilder.SafeSqlAppend(whereClause);
          filter.Parameters.AddRange(@params);
        }
      }

      return filter;
    }
  }
}

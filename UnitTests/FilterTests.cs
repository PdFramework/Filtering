using System.Data.SqlClient;
using System.Linq;
using Framework.Filtering.UnitTests.TestObjects;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Framework.Filtering;
using PeinearyDevelopment.Framework.Filtering.Data.Entity;
using PeinearyDevelopment.Framework.Filtering.Extensions;
using PeinearyDevelopment.Framework.Filtering.FilterCriteria;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace Framework.Filtering.UnitTests
{
  [TestClass]
  public class FilterTests
  {
    #region MappedProperties
    [TestMethod]
    public void Given_AType_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheSchema()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<TestClass>();
        Assert.AreEqual("dbo", properties.DbSchema);
      }
    }

    [TestMethod]
    public void Given_AType_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheTableName()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<TestClass>();
        Assert.AreEqual("TestClasses", properties.DbTableName);
      }
    }

    [TestMethod]
    public void Given_AType_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainThePrimaryKey()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<TestClass>();
        Assert.AreEqual("Id", properties.PrimaryKeyPropertyName);
      }
    }

    [TestMethod]
    public void Given_AType_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheProperties()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<TestClass>();

        Assert.AreEqual("Id", properties.ObjectPropertyColumnNameMapper["Id"]);
        Assert.AreEqual("Name", properties.ObjectPropertyColumnNameMapper["Name"]);
        Assert.AreEqual("StartDateTime", properties.ObjectPropertyColumnNameMapper["StartDateTime"]);
        Assert.AreEqual("EndDateTimeOffset", properties.ObjectPropertyColumnNameMapper["EndDateTimeOffset"]);
        Assert.AreEqual("IsActive", properties.ObjectPropertyColumnNameMapper["IsActive"]);
      }
    }
    #endregion

    #region CustomMappedProperties
    [TestMethod]
    public void Given_ATypeWithACustomSchema_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomSchema()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<CustomTestClass>();
        Assert.AreEqual((object)Contstants.CustomSchemaName, properties.DbSchema);
      }
    }

    [TestMethod]
    public void Given_ATypeWithACustomTableName_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomTableName()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<CustomTestClass>();
        Assert.AreEqual((object)Contstants.CustomTableName, properties.DbTableName);
      }
    }

    [TestMethod]
    public void Given_ATypeWithACustomPrimaryKey_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomPrimaryKey()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<CustomTestClass>();
        Assert.AreEqual((object)Contstants.CustomKeyName, properties.PrimaryKeyPropertyName);
        Assert.AreEqual("Id", properties.ObjectPropertyColumnNameMapper["Id"]);
        Assert.AreEqual("StartDateTime", properties.ObjectPropertyColumnNameMapper["StartDateTime"]);
        Assert.AreEqual("EndDateTimeOffset", properties.ObjectPropertyColumnNameMapper["EndDateTimeOffset"]);
        Assert.AreEqual("IsActive", properties.ObjectPropertyColumnNameMapper["IsActive"]);
      }
    }

    [TestMethod]
    public void Given_ATypeWithACustomColumnMapping_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomMapping()
    {
      using (var context = new TestDbContext())
      {
        var properties = context.MapDbProperties<CustomTestClass>();

        Assert.AreEqual((object)Contstants.CustomColumnName, properties.ObjectPropertyColumnNameMapper["Name"]);
      }
    }
    #endregion

    [TestMethod]
    public void Given_AFilterBuilderThatShouldReturnAllResults_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      const bool returnAllResults = true;

      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass> { ReturnAllResults = returnAllResults };

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] ORDER BY [Id]", filter.SqlQueryStringBuilder.ToString());
      }
    }

    [TestMethod]
    public void Given_AFilterBuilderThatHasAPageSizeAndPageIndex_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      const int pageIndex = 1;
      const int pageSize = 100;
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass> { PageIndex = pageIndex, PageSize = pageSize };

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] ORDER BY [Id] OFFSET {pageIndex * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
      }
    }

    [TestMethod]
    public void Given_AFilterBuilderThatShouldReturnAllResultsWithAWhereFilter_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass> { ReturnAllResults = true };
        filterBuilder.Where(tc => tc.Id, NumericFilterType.Equals, 1);

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] = @p0 ORDER BY [Id]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters.First()).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters.First()).Value);
      }
    }

    [TestMethod]
    public void Given_AFilterBuilderThatShouldReturnAllResultsWithACompoundAndFilter_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass> { ReturnAllResults = true };
        filterBuilder.Where(tc => tc.Id, NumericFilterType.Equals, 1)
                     .And(tc => tc.Name, StringFilterType.StartsWith, "Foo");

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY [Id]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void Given_AFilterBuilderThatShouldReturnAllResultsWithACompoundOrFilter_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                    .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                    .Or(tc => tc.Name, StringFilterType.StartsWith, "Foo")
                                    .ReturnAllResults();

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY [Id]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void Given_AFilterBuilderThatShouldReturnAllResultsWithACompoundOrAndNestedAndFilters_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(new IntegerCriterion<TestClass>(t => t.Id, NumericFilterType.Equals, 2)
                                                            .And(new StringCriterion<TestClass>(t => t.Name, StringFilterType.StartsWith, "Foo")))
                                                  .ReturnAllResults();

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY [Id]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual(2, ((SqlParameter)filter.Parameters[1]).Value);
        Assert.AreEqual("p2", ((SqlParameter)filter.Parameters[2]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[2]).Value);
      }
    }

    [TestMethod]
    public void Given_AFilterBuilder_When_FilterIsCreated_Then_FilterQueryStringShouldMatchExpectations()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>().Where(tc => tc.Id, NumericFilterType.Equals, 1);

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] = @p0 ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters.First()).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters.First()).Value);
      }
    }

    [TestMethod]
    public void h()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .And(tc => tc.Name, StringFilterType.StartsWith, "Foo");

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void i()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(tc => tc.Name, StringFilterType.StartsWith, "Foo");

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void j()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(new IntegerCriterion<TestClass>(t => t.Id, NumericFilterType.Equals, 2)
                                                            .And(new StringCriterion<TestClass>(t => t.Name, StringFilterType.StartsWith, "Foo")));

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual(2, ((SqlParameter)filter.Parameters[1]).Value);
        Assert.AreEqual("p2", ((SqlParameter)filter.Parameters[2]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[2]).Value);
      }
    }

    [TestMethod]
    public void p()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<TestClass>()
                                                  .Where(tc => tc.Id, SetFilterType.In, new[] { 1, 2 });

        var filter = new Filter<TestClass>(context, filterBuilder);

        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] IN (@p0, @p1) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual(2, ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void k()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>().ReturnAllResults();

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] ORDER BY [{Contstants.CustomKeyName}]", filter.SqlQueryStringBuilder.ToString());
      }
    }

    [TestMethod]
    public void l()
    {
      const int pageIndex = 1;
      const int pageSize = 100;
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>().SkipPages(pageIndex).Take(pageSize);

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] ORDER BY [{Contstants.CustomKeyName}] OFFSET {pageIndex * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
      }
    }

    [TestMethod]
    public void m()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>().Where(tc => tc.Id, NumericFilterType.Equals, 1).ReturnAllResults();

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE [Id] = @p0 ORDER BY [{Contstants.CustomKeyName}]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters.First()).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters.First()).Value);
      }
    }

    [TestMethod]
    public void n()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .And(tc => tc.Name, StringFilterType.StartsWith, "Foo")
                                                  .ReturnAllResults();

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 AND [{Contstants.CustomColumnName}] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void o()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(tc => tc.Name, StringFilterType.StartsWith, "Foo")
                                                  .ReturnAllResults();

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 OR [{Contstants.CustomColumnName}] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void q()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(new IntegerCriterion<CustomTestClass>(t => t.Id, NumericFilterType.Equals, 2)
                                                            .And(new StringCriterion<CustomTestClass>(t => t.Name, StringFilterType.StartsWith, "Foo")))
                                                  .ReturnAllResults();

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [{Contstants.CustomColumnName}] LIKE @p2 + '%' ) ) ORDER BY [{Contstants.CustomKeyName}]", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual(2, ((SqlParameter)filter.Parameters[1]).Value);
        Assert.AreEqual("p2", ((SqlParameter)filter.Parameters[2]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[2]).Value);
      }
    }

    [TestMethod]
    public void r()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>().Where(tc => tc.Id, NumericFilterType.Equals, 1);

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE [Id] = @p0 ORDER BY [{Contstants.CustomKeyName}] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters.First()).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters.First()).Value);
      }
    }

    [TestMethod]
    public void s()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .And(tc => tc.Name, StringFilterType.StartsWith, "Foo");

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 AND [{Contstants.CustomColumnName}] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void t()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(tc => tc.Name, StringFilterType.StartsWith, "Foo");

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 OR [{Contstants.CustomColumnName}] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[1]).Value);
      }
    }

    [TestMethod]
    public void u()
    {
      using (var context = new TestDbContext())
      {
        var filterBuilder = new FilterBuilder<CustomTestClass>()
                                                  .Where(tc => tc.Id, NumericFilterType.Equals, 1)
                                                  .Or(new IntegerCriterion<CustomTestClass>(t => t.Id, NumericFilterType.Equals, 2)
                                                            .And(new StringCriterion<CustomTestClass>(t => t.Name, StringFilterType.StartsWith, "Foo")));

        var filter = new Filter<CustomTestClass>(context, filterBuilder);

        Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [{Contstants.CustomColumnName}] LIKE @p2 + '%' ) ) ORDER BY [{Contstants.CustomKeyName}] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", filter.SqlQueryStringBuilder.ToString());
        Assert.AreEqual("p0", ((SqlParameter)filter.Parameters[0]).ParameterName);
        Assert.AreEqual(1, ((SqlParameter)filter.Parameters[0]).Value);
        Assert.AreEqual("p1", ((SqlParameter)filter.Parameters[1]).ParameterName);
        Assert.AreEqual(2, ((SqlParameter)filter.Parameters[1]).Value);
        Assert.AreEqual("p2", ((SqlParameter)filter.Parameters[2]).ParameterName);
        Assert.AreEqual("Foo", ((SqlParameter)filter.Parameters[2]).Value);
      }
    }
  }
}

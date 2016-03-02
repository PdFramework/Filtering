using System.Data.SqlClient;

namespace Framework.QueryBuilder.UnitTests
{
    using Data.Entity;
    using Extensions;
    using Microsoft.VisualStudio.TestTools.UnitTesting;
    using SearchCriteria;
    using SearchTypes;
    using System.Linq;

    [TestClass]
    public class UnitTest1
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
                Assert.AreEqual(Contstants.CustomSchemaName, properties.DbSchema);
            }
        }

        [TestMethod]
        public void Given_ATypeWithACustomTableName_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomTableName()
        {
            using (var context = new TestDbContext())
            {
                var properties = context.MapDbProperties<CustomTestClass>();
                Assert.AreEqual(Contstants.CustomTableName, properties.DbTableName);
            }
        }

        [TestMethod]
        public void Given_ATypeWithACustomPrimaryKey_When_MapDbPropertiesIsInvoked_Then_MappedPropertiesShouldContainTheCustomPrimaryKey()
        {
            using (var context = new TestDbContext())
            {
                var properties = context.MapDbProperties<CustomTestClass>();
                Assert.AreEqual(Contstants.CustomKeyName, properties.PrimaryKeyPropertyName);
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
                
                Assert.AreEqual(Contstants.CustomColumnName, properties.ObjectPropertyColumnNameMapper["Name"]);
            }
        }
        #endregion

        [TestMethod]
        public void a()
        {
            const bool returnAllResults = true;

            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(returnAllResults);

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] ORDER BY [Id]", queryBuilder.StringBuilder.ToString());
            }
        }

        [TestMethod]
        public void b()
        {
            const int pageIndex = 1;
            const int pageSize = 100;
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(pageIndex, pageSize);

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] ORDER BY [Id] OFFSET {pageIndex * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY", queryBuilder.StringBuilder.ToString());
            }
        }

        [TestMethod]
        public void c()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(true).Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] = @p0 ORDER BY [Id]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters.First()).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters.First()).Value);
            }
        }

        [TestMethod]
        public void d()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(true)
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY [Id]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        [TestMethod]
        public void e()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(true)
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .Or(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY [Id]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        [TestMethod]
        public void f()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(true)
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .Or(sc => sc
                                                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 2 })
                                                                    .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" }));

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY [Id]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual(2, ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
                Assert.AreEqual("p2", ((SqlParameter)queryBuilder.QueryParameters[2]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[2]).Value);
            }
        }

        [TestMethod]
        public void g()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>().Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] = @p0 ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters.First()).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters.First()).Value);
            }
        }

        [TestMethod]
        public void h()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        [TestMethod]
        public void i()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .Or(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        [TestMethod]
        public void j()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .Or(sc => sc
                                                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 2 })
                                                                    .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" }));

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY [Id] OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual(2, ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
                Assert.AreEqual("p2", ((SqlParameter)queryBuilder.QueryParameters[2]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[2]).Value);
            }
        }

        [TestMethod]
        public void k()
        {
            const bool returnAllResults = true;

            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<CustomTestClass>(returnAllResults);

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] ORDER BY [{Contstants.CustomKeyName}]", queryBuilder.StringBuilder.ToString());
            }
        }

        [TestMethod]
        public void l()
        {
            const int pageIndex = 1;
            const int pageSize = 100;
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<CustomTestClass>(pageIndex, pageSize);

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] ORDER BY [{Contstants.CustomKeyName}] OFFSET {pageIndex * pageSize} ROWS FETCH NEXT {pageSize} ROWS ONLY", queryBuilder.StringBuilder.ToString());
            }
        }

        [TestMethod]
        public void m()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<CustomTestClass>(true).Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE [Id] = @p0 ORDER BY [{Contstants.CustomKeyName}]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters.First()).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters.First()).Value);
            }
        }

        [TestMethod]
        public void n()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<CustomTestClass>(true)
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        [TestMethod]
        public void o()
        {
            using (var context = new TestDbContext())
            {
                var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<CustomTestClass>(true)
                                                          .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                                          .Or(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

                var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

                Assert.AreEqual($"SELECT [StartDateTime] AS [StartDateTime], [Id] AS [Id], [{Contstants.CustomColumnName}] AS [Name], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [{Contstants.CustomSchemaName}].[{Contstants.CustomTableName}] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY [{Contstants.CustomKeyName}]", queryBuilder.StringBuilder.ToString());
                Assert.AreEqual("p0", ((SqlParameter)queryBuilder.QueryParameters[0]).ParameterName);
                Assert.AreEqual(1, ((SqlParameter)queryBuilder.QueryParameters[0]).Value);
                Assert.AreEqual("p1", ((SqlParameter)queryBuilder.QueryParameters[1]).ParameterName);
                Assert.AreEqual("Foo", ((SqlParameter)queryBuilder.QueryParameters[1]).Value);
            }
        }

        //[TestMethod]
        //public void f()
        //{
        //    using (var context = new TestDbContext())
        //    {
        //        var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>(true)
        //                                                  .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                                  .Or(sc => sc
        //                                                            .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 2 })
        //                                                            .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" }));

        //        var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

        //        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY Id", queryBuilder.StringBuilder.ToString());
        //        Assert.AreEqual("p0", queryBuilder.QueryParameters[0].ParameterName);
        //        Assert.AreEqual(1, queryBuilder.QueryParameters[0].Value);
        //        Assert.AreEqual("p1", queryBuilder.QueryParameters[1].ParameterName);
        //        Assert.AreEqual(2, queryBuilder.QueryParameters[1].Value);
        //        Assert.AreEqual("p2", queryBuilder.QueryParameters[2].ParameterName);
        //        Assert.AreEqual("Foo", queryBuilder.QueryParameters[2].Value);
        //    }
        //}

        //[TestMethod]
        //public void g()
        //{
        //    using (var context = new TestDbContext())
        //    {
        //        var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>().Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 });

        //        var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

        //        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE [Id] = @p0 ORDER BY Id OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
        //        Assert.AreEqual("p0", queryBuilder.QueryParameters.First().ParameterName);
        //        Assert.AreEqual(1, queryBuilder.QueryParameters.First().Value);
        //    }
        //}

        //[TestMethod]
        //public void h()
        //{
        //    using (var context = new TestDbContext())
        //    {
        //        var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
        //                                                  .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                                  .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

        //        var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

        //        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 AND [Name] LIKE @p1 + '%' ) ORDER BY Id OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
        //        Assert.AreEqual("p0", queryBuilder.QueryParameters[0].ParameterName);
        //        Assert.AreEqual(1, queryBuilder.QueryParameters[0].Value);
        //        Assert.AreEqual("p1", queryBuilder.QueryParameters[1].ParameterName);
        //        Assert.AreEqual("Foo", queryBuilder.QueryParameters[1].Value);
        //    }
        //}

        //[TestMethod]
        //public void i()
        //{
        //    using (var context = new TestDbContext())
        //    {
        //        var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
        //                                                  .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                                  .Or(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" });

        //        var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

        //        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR [Name] LIKE @p1 + '%' ) ORDER BY Id OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
        //        Assert.AreEqual("p0", queryBuilder.QueryParameters[0].ParameterName);
        //        Assert.AreEqual(1, queryBuilder.QueryParameters[0].Value);
        //        Assert.AreEqual("p1", queryBuilder.QueryParameters[1].ParameterName);
        //        Assert.AreEqual("Foo", queryBuilder.QueryParameters[1].Value);
        //    }
        //}

        //[TestMethod]
        //public void j()
        //{
        //    using (var context = new TestDbContext())
        //    {
        //        var searchCriteria = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
        //                                                  .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                                  .Or(sc => sc
        //                                                            .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 2 })
        //                                                            .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Foo" }));

        //        var queryBuilder = QueryBuilderExtensions.CreateQueryBuilder(context, searchCriteria);

        //        Assert.AreEqual("SELECT [Id] AS [Id], [Name] AS [Name], [StartDateTime] AS [StartDateTime], [EndDateTimeOffset] AS [EndDateTimeOffset], [IsActive] AS [IsActive] FROM [dbo].[TestClasses] WHERE ( [Id] = @p0 OR ( [Id] = @p1 AND [Name] LIKE @p2 + '%' ) ) ORDER BY Id OFFSET 0 ROWS FETCH NEXT 10 ROWS ONLY", queryBuilder.StringBuilder.ToString());
        //        Assert.AreEqual("p0", queryBuilder.QueryParameters[0].ParameterName);
        //        Assert.AreEqual(1, queryBuilder.QueryParameters[0].Value);
        //        Assert.AreEqual("p1", queryBuilder.QueryParameters[1].ParameterName);
        //        Assert.AreEqual(2, queryBuilder.QueryParameters[1].Value);
        //        Assert.AreEqual("p2", queryBuilder.QueryParameters[2].ParameterName);
        //        Assert.AreEqual("Foo", queryBuilder.QueryParameters[2].Value);
        //    }
        //}
    }
}

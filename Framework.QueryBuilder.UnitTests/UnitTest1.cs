namespace Framework.QueryBuilder.UnitTests
{
    using Framework.QueryBuilder.Extensions;
    using Framework.QueryBuilder.SearchCriteria;
    using Framework.QueryBuilder.SearchTypes;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new TestClass().CreateSearchCriteria()
                                   .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                   .AndWhere(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test"});

            var b = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
                                            .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                            .AndWhere(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" });

            var c = new SearchCriteriaBuilder<TestClass>()
                            .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                            .AndWhere(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" })
                            .OrWhere(tc => tc.IsActive, new BooleanSearchCriteria { SearchType = BooleanSearchType.Equals, SearchValue = true });

            var d = new TestClass().CreateSearchCriteria()
                .Where(tc => tc.Id, new IntegerSearchCriteria {SearchType = IntegerSearchType.Equals, SearchValue = 1})
                .AndWhere(sc => sc
                            .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                            .OrWhere(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));

            var e = new TestClass().CreateSearchCriteria()
                        .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                        .OrWhere(sc => sc
                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                    .AndWhere(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));
        }
    }
}

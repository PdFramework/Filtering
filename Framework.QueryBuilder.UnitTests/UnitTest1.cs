namespace Framework.QueryBuilder.UnitTests
{
    using Data.Entity;
    using Extensions;
    using SearchCriteria;
    using SearchTypes;
    using System.Diagnostics;
    using System.Linq;
    using Microsoft.VisualStudio.TestTools.UnitTesting;

    [TestClass]
    public class UnitTest1
    {
        [TestMethod]
        public void TestMethod1()
        {
            var a = new TestClass().CreateSearchCriteria()
                                   .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                   .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test"})
                                   .OrderBy(tc => tc.Id, SortType.Descending);

            var b = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
                                            .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                            .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" });

            var c = new SearchCriteriaBuilder<TestClass>()
                            .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                            .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" })
                            .Or(tc => tc.IsActive, new BooleanSearchCriteria { SearchType = BooleanSearchType.Equals, SearchValue = true });

            var d = new TestClass().CreateSearchCriteria()
                .Where(tc => tc.Id, new IntegerSearchCriteria {SearchType = IntegerSearchType.Equals, SearchValue = 1})
                .And(sc => sc
                            .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                            .Or(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));

            var e = new TestClass().CreateSearchCriteria()
                        .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                        .Or(sc => sc
                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                    .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));
            var f = new TestClass().CreateSearchCriteria()
                                   .Where(tc => tc.Id, new IntegerSearchCriteria {SearchType = IntegerSearchType.Equals, SearchValue = 1})
                                   .OrderBy(tc => tc.Id)
                                   .OrderBy(tc => tc.Name, SortType.Descending).ReturnAllResults();
        }

        [TestMethod]
        public void TestMethod2()
        {
            var sw = Stopwatch.StartNew();
            var e = new TestClass().CreateSearchCriteria()
                        .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                        .Or(sc => sc
                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
                                    .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));

            //var a = new TestClass().CreateSearchCriteria()
            //           .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
            //           .AndWhere(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" });
            var d = sw.Elapsed;
            using (var context = new TestDbContext())
            {
                var a = context.TestObjects.Any(t => t.IsActive);
            }

            using (var context = new TestDbContext())
            {
                var sw2 = Stopwatch.StartNew();

                context.TestObjects.Search(context, e);
                var f = sw2.Elapsed;
            }
        }
    }
}

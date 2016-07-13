using Microsoft.VisualStudio.TestTools.UnitTesting;
using PeinearyDevelopment.Framework.Filtering.Data.Entity;
using PeinearyDevelopment.Framework.Filtering.Extensions;
using PeinearyDevelopment.Framework.Filtering.FilterTypes;

namespace PeinearyDevelopment.Framework.Filtering.IntegrationTests
{
    [TestClass]
    public class IntegrationTest1
    {
        [TestMethod]
        public void a()
        {
            using (var context = new TestDbContext())
            {
                //var sw2 = Stopwatch.StartNew();

                var a = context.CustomTestObjects.Search(context, new FilterBuilder<CustomTestClass>().Where(sc => sc.Name, StringFilterType.Equals, "foo"));
                //var f = sw2.Elapsed;



                // var a = QueryBuilderExtensions.CreateQueryBuilder(context, e);
            }
        }

        //[TestMethod]
        //public void TestMethod1()
        //{
        //    var a = new TestClass().CreateSearchCriteria()
        //                           .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                           .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" })
        //                           .OrderBy(tc => tc.Id, SortType.Descending);

        //    var b = SearchCriteriaBuilder.CreateSearchCriteria<TestClass>()
        //                                    .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                    .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" });

        //    var c = new SearchCriteriaBuilder<TestClass>()
        //                    .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                    .And(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" })
        //                    .Or(tc => tc.IsActive, new BooleanSearchCriteria { SearchType = BooleanSearchType.Equals, SearchValue = true });

        //    var d = new TestClass().CreateSearchCriteria()
        //        .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //        .And(sc => sc
        //                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                    .Or(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));

        //    var e = new TestClass().CreateSearchCriteria()
        //                .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                .Or(sc => sc
        //                            .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                            .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));
        //    var f = new TestClass().CreateSearchCriteria()
        //                           .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                           .OrderBy(tc => tc.Id)
        //                           .OrderBy(tc => tc.Name, SortType.Descending).ReturnAllResults();
        //}

        //        [TestMethod]
        //        public void TestMethod2()
        //        {
        //            var sw = Stopwatch.StartNew();
        //            var e = new TestClass().CreateSearchCriteria()
        //                        .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                        .Or(sc => sc
        //                                    .Where(t => t.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //                                    .And(t => t.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" }));

        //            //var a = new TestClass().CreateSearchCriteria()
        //            //           .Where(tc => tc.Id, new IntegerSearchCriteria { SearchType = IntegerSearchType.Equals, SearchValue = 1 })
        //            //           .AndWhere(tc => tc.Name, new StringSearchCriteria { SearchType = StringSearchType.StartsWith, SearchValue = "Test" });
        //            var d = sw.Elapsed;
        //            using (var context = new TestDbContext())
        //            {
        //                var a = context.TestObjects.Any(t => t.IsActive);
        //            }

        //            using (var context = new TestDbContext())
        //            {
        //                var sw2 = Stopwatch.StartNew();

        //                context.TestObjects.Search(context, e);
        //                var f = sw2.Elapsed;



        //               // var a = QueryBuilderExtensions.CreateQueryBuilder(context, e);
        //            }
        //}
    }
}

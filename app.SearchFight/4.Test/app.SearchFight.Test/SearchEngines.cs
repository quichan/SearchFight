using app.SearchFight.Implementation;
using app.SearchFight.Interface;
using app.SearchFight.Test.Sample;
using Microsoft.VisualStudio.TestTools.UnitTesting;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.SearchFight.Test
{
    [TestClass]
    public class SearchEngines
    {

        [TestMethod()]
        public void MultipleLanguages()
        {
            //Arrange
            var searchEngines = GetMocks();
            var queryMaker = new QueryMaker(searchEngines);

            //Act
            var languages = new string[] { "Python", "c#", "JAVA", ".NET", "NetCore" };
            var results = queryMaker.QuerySearchEngines(languages);

            //Assert
            var searchEngineTotal = searchEngines.Count();
            Assert.AreEqual(5 * searchEngineTotal, results.Count());

            foreach (var language in languages)
            {
                AssertIsValidResult(results, searchEngineTotal, language);

            }

            AssertTotalGreaterOrEqualThanZero(results);

        }

        private static void AssertTotalGreaterOrEqualThanZero(IEnumerable<ISearchResult> searchResults)
        {
            var searchesWithZeroOrLessResults = searchResults.Where(searchResult => searchResult.Total <= 0).Count();
            Assert.IsTrue(searchesWithZeroOrLessResults == 0);
        }

        private void AssertIsValidResult(IEnumerable<ISearchResult> searchResults, int totalEngines, string language)
        {
            var searchesByLanguage = searchResults.Where(searchResult => searchResult.SearchTerm == language);

            var totalResponse = searchesByLanguage.Count();
            Assert.AreEqual(totalEngines, totalResponse);

            var searchEnginesUsed = searchesByLanguage.GroupBy(searchResult => searchResult.SearchEngine).Count();
            Assert.AreEqual(searchEnginesUsed, totalEngines);
        }

        private IEnumerable<ISearchEngine> GetMocks()
        {
            var google = new Google();
            var bing = new Bing();

            return new List<ISearchEngine> { google, bing };

        }
    }
}

using app.SearchFight.Consoles.ViewModel;
using app.SearchFight.Implementation;
using System;
using System.Collections.Generic;
using System.Linq;

namespace app.SearchFight.Consoles.View
{
    public class Result
    {
        public static void Print(IEnumerable<SearchViewModel> searchResults)
        {
            var resultsByProgrammingLanguage = FetchDataByLanguage(searchResults);
            var winnersBySearchEngine = FetchLanguageWinner(searchResults);

            foreach (var result in resultsByProgrammingLanguage)
            {
                Console.WriteLine(result);
            }

            foreach (var winner in winnersBySearchEngine)
            {
                Console.WriteLine(winner);
            }

            Console.ReadLine();
        }

        private static IEnumerable<string> FetchDataByLanguage(IEnumerable<SearchViewModel> searchResults)
        {
            var results = new List<string>();

            var data = searchResults.GroupBy(searchResult => searchResult.Word);


            foreach (var item in data)
            {
                var result = item.Key + " : ";

                foreach (var searchResult in item)
                {
                    result += searchResult.Engine + " : " + searchResult.Total + " ";
                }
                results.Add(result);
            }

            return results;
        }

        private static IEnumerable<string> FetchLanguageWinner(IEnumerable<SearchViewModel> searchResults)
        {
            var results = new List<string>();
            var data = searchResults.GroupBy(searchResult => searchResult.Engine);

            foreach (var item in data)
            {
                SearchViewModel top = item.OrderByDescending(x => x.Total).FirstOrDefault();
                results.Add(item.Key + " Winner : " + top.Word);
            }

            return results;
        }


    }
}

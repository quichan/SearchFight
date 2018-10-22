using app.SearchFight.Interface;

namespace app.SearchFight.Test.Sample
{
    class Bing : ISearchEngine
    {
        public ISearchResult Search(string stringToSearch)
        {
            var searchResultMock = new EngineMock();
            searchResultMock.SearchTerm = stringToSearch;
            searchResultMock.SearchEngine = "Bing";
            searchResultMock.Total = 322;

            return searchResultMock;
        }
    }
}

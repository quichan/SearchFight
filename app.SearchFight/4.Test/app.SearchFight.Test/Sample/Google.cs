using app.SearchFight.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.SearchFight.Test.Sample
{
    public class Google : ISearchEngine
    {
        public ISearchResult Search(string stringToSearch)
        {
            var searchResultMock = new EngineMock();
            searchResultMock.SearchTerm = stringToSearch;
            searchResultMock.SearchEngine = "Google";
            searchResultMock.Total = 322;

            return searchResultMock;
        }


    }
}

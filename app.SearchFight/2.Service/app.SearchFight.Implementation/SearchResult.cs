namespace app.SearchFight.Implementation
{
    using app.SearchFight.Interface;
    using System;
    public class SearchResult : ISearchResult
    {
        public string SearchEngine { get; set; }

        public string SearchTerm { get; set; }

        public long Total { get; set; }
    }
}

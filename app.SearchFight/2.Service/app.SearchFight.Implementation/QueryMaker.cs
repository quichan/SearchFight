namespace app.SearchFight.Implementation
{
    using System;
    using System.Collections.Generic;
    using app.SearchFight.Interface;
    using System.Linq.Expressions;

    public class QueryMaker : IQueryMaker
    {
        public readonly IEnumerable<ISearchEngine> listSearchEngines = null;

        public QueryMaker(IEnumerable<ISearchEngine> listSearchEngines)
        {
            if (listSearchEngines == null) throw new System.NotImplementedException();

            this.listSearchEngines = listSearchEngines;
            
        }
        public IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> searchTerms)
        {
            var results = new List<ISearchResult>();

            foreach (var term in searchTerms)
            {
                foreach (var engine in listSearchEngines)
                {
                    var result = engine.Search(term);
                    results.Add(result);
                }
            }
            return results;
        }

    }
}

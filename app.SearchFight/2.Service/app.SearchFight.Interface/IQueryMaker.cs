namespace app.SearchFight.Interface
{
    using System.Collections.Generic;
    public interface IQueryMaker
    {
        IEnumerable<ISearchResult> QuerySearchEngines(IEnumerable<string> searchTerms);

    }
}

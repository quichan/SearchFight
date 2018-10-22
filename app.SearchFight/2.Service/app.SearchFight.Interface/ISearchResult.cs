namespace app.SearchFight.Interface
{
    public interface ISearchResult
    {
        string SearchEngine { get; set; }

        string SearchTerm { get; set; }

        long Total { get; set; }

    }
}

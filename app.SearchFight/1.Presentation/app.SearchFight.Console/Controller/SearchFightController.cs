namespace app.SearchFight.Consoles.Controller
{
    using app.SearchFight.Implementation;
    using app.SearchFight.Interface;
    using System;
    using System.Collections.Generic;
    using System.Text;
    using System.Linq;
    using app.SearchFight.Consoles.ViewModel;

    public class SearchFightController
    {
        private readonly IQueryMaker queryMaker;

        public SearchFightController(IQueryMaker queryMaker)
        {
            if (queryMaker == null)
            {
                throw new ArgumentNullException("queryMaker");
            }

            this.queryMaker = queryMaker;
        }

        public IEnumerable<SearchViewModel> FindResult(string[] programmingLanguages)
        {
            var searchResults = queryMaker.QuerySearchEngines(programmingLanguages);

            List<SearchViewModel> model = new List<SearchViewModel>();

            searchResults.ToList().ForEach(x =>
            {
                model.Add(new SearchViewModel(x.SearchEngine, x.SearchTerm, x.Total));                
            });

            return model;
        }


    }
}

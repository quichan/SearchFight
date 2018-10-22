namespace app.SearchFight.Implementation
{
    using app.SearchFight.Exceptions;
    using app.SearchFight.Interface;
    using Newtonsoft.Json;
    using Newtonsoft.Json.Linq;
    using System;
    using System.Net.Http;

    public abstract class SearchEngine : ISearchEngine
    {       
        protected readonly IHttpHandler httpHandler;

        protected abstract string GetUrl(string searchTerm);
        protected abstract void AddRequestHeaders();
        protected abstract long GetTotalResults(dynamic jObj);

        public SearchEngine(IHttpHandler httpHandler)
        {
            if (httpHandler == null) throw new ArgumentNullException("httpHandler");
            this.httpHandler = httpHandler;
        }

        public ISearchResult Search(string searchTerm)
        {
            AddRequestHeaders();
            try
            {
                var response = httpHandler.GetAsync(GetUrl(searchTerm)).Result;
                if (response.IsSuccessStatusCode)
                {
                    var json = response.Content.ReadAsStringAsync().Result;
                    return this.Parse(json, searchTerm);
                }
                else
                {                    
                    throw new SearchEngineResponseException();
                }
            }
            catch (AggregateException ex)
            {
                ex.Handle((x) =>
                {
                    if (x is TimeoutException)
                    {
                        throw new TimeOutException();                        
                    }
                    else if (x is HttpRequestException)
                    {
                        throw new ConnectionException();
                    }
                    throw x;
                });                
                throw ex;
            }
        }

        private ISearchResult Parse(string json, string searchTerm)
        {

            //Deserialize the string to JSON object
            dynamic jObj = (JObject)JsonConvert.DeserializeObject(json);


            SearchResult searchResult = new SearchResult()
            {
                Total = GetTotalResults(jObj),
                SearchEngine = ToString(),
                SearchTerm = searchTerm

            };

            searchResult.SearchEngine = ToString();
            searchResult.SearchTerm = searchTerm;
            searchResult.Total = GetTotalResults(jObj);

            return searchResult;
        }

    }
}

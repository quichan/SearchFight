namespace app.SearchFight.Implementation.SearchEngines
{
    using app.SearchFight.Interface;
    using appSearchFight.Common;

    public class Bing : SearchEngine
    {
        private string apiKey = Configuration.GetConfiguration("BingAPI_Key");//1e82a59aba224491aa5d959aa641a773
        private string uri = Configuration.GetConfiguration("BingAPI");

        public Bing(IHttpHandler httpHandler) : base(httpHandler)
        {
            
        }
        

        //public override GetUrl
        protected override void AddRequestHeaders()
        {
            httpHandler.AddRequestHeader("Ocp-Apim-Subscription-Key", apiKey);
        }

        protected override long GetTotalResults(dynamic jObj)
        {
            return jObj["webPages"]["totalEstimatedMatches"];
        }

        protected override string GetUrl(string searchTerm)
        {
            return uri + "?q=" + searchTerm;
        }
        public override string ToString()
        {
            return "Bing";
        }
    }
}

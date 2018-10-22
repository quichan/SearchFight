namespace app.SearchFight.Implementation.SearchEngines
{
    using System;
    using app.SearchFight.Interface;
    using appSearchFight.Common;
    public class Google : SearchEngine
    {
        private  string apiKey = Configuration.GetConfiguration("GoogleAPI_Key");
        private  string customSearchEngineID = Configuration.GetConfiguration("GoogleAPI_ID");
        private  string uri = Configuration.GetConfiguration("GoogleAPI");

        public Google(IHttpHandler httpHandler) : base(httpHandler)
        {
        }

        protected override void AddRequestHeaders()
        {
           
        }

        protected override long GetTotalResults(dynamic jObj)
        {
            return Convert.ToInt64(jObj["queries"]["request"][0]["totalResults"]);
        }

        protected override string GetUrl(string searchTerm)
        {
            return uri + "?key=" + apiKey + "&cx=" + customSearchEngineID + "&q=" + searchTerm;
        }
        public override string ToString()
        {
            return "Google";
        }
    }
}

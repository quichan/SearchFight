namespace app.SearchFight.Implementation
{
    using app.SearchFight.Interface;
    using System;
    using System.Net.Http;
    using System.Net.Http.Headers;   
    using System.Threading.Tasks;

    public class HttpHandler : IHttpHandler
    {
        private HttpClient client;

        public HttpHandler()
        {
            client = new HttpClient();
            client.Timeout = TimeSpan.FromSeconds(10);
            client.DefaultRequestHeaders.Accept.Clear();
            client.DefaultRequestHeaders.Accept.Add(new MediaTypeWithQualityHeaderValue("application/json"));
        }

        public HttpResponseMessage Get(string url)
        {

            throw new NotImplementedException();
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }

        public void AddRequestHeader(string name, string value)
        {
            client.DefaultRequestHeaders.Add(name, value);
        }

        Task<HttpResponseMessage> IHttpHandler.GetAsync(string url)
        {
            return client.GetAsync(url);
        }

        Task<HttpResponseMessage> IHttpHandler.GetAsync(string url, HttpContent content)
        {
            throw new NotImplementedException();
        }
    }
}

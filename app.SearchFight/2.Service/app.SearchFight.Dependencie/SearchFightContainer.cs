namespace app.SearchFight.Dependencies
{
    using app.SearchFight.Interface;
    using SimpleInjector;    
    using app.SearchFight.Implementation;
    using app.SearchFight.Implementation.SearchEngines;

    public class SearchFightContainer
    {
        private static Container _container;
        public static Container BuildContainer()
        {
            _container = new Container();
            _container.Register<IQueryMaker, QueryMaker>(Lifestyle.Singleton);            
            _container.Collection.Register<ISearchEngine>(new[] { typeof(Google), typeof(Bing) });
            _container.Register<IHttpHandler, HttpHandler>(Lifestyle.Singleton);

            _container.Verify();

            return _container;
        }
    }
}

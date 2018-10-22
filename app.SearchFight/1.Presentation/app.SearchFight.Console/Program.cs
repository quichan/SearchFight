namespace app.SearchFight.Consoles
{
    using app.SearchFight.Consoles.Controller;
    using app.SearchFight.Consoles.View;
    using app.SearchFight.Dependencies;
    using app.SearchFight.Interface;
    using SimpleInjector;
    using System;

    class Program
    {

        static void Main(string[] args)
        {

#if (DEBUG)
            args = new[] { ".NET", "JAVA" };
#endif
            Container container = SearchFightContainer.BuildContainer();

            var queryMaker = container.GetInstance<IQueryMaker>();

            try
            {
                var connection = new SearchFightController(queryMaker);
                var model = connection.FindResult(args);

                Result.Print(model);

            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}

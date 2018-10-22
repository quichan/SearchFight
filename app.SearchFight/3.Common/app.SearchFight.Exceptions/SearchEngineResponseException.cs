namespace app.SearchFight.Exceptions
{
    using System;
    public class SearchEngineResponseException : Exception
    {
        public override string Message
        {
            get
            {
                return "Unable to connect to the Searh Engine";
            }
        }
    }
}

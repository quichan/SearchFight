namespace app.SearchFight.Exceptions
{
    using System;
    public class ConnectionException : Exception
    {
        public override string Message
        {
            get
            {
                return "Unable to connect to the database";
            }
        }
    }
}

namespace app.SearchFight.Exceptions
{
    using System;
    using System.Collections.Generic;
    using System.Text;

    public class TimeOutException : Exception
    {
        public override string Message
        {
            get
            {
                return "A time out has ocurred while performing a search.";
            }
        }
    }
}

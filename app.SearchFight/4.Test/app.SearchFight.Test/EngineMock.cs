using app.SearchFight.Interface;
using System;
using System.Collections.Generic;
using System.Text;

namespace app.SearchFight.Test
{
    public class EngineMock : ISearchResult
    {
        public string SearchTerm { get; set; }
        public string SearchEngine { get; set; }
        public long Total { get; set; }
    }
}

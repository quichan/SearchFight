using System;
using System.Collections.Generic;
using System.Text;

namespace app.SearchFight.Consoles.ViewModel
{
    public class SearchViewModel
    {
        public string Engine { get; set; }

        public string Word { get; set; }

        public long Total { get; set; }



        public SearchViewModel(string engine, string word, long total)
        {
            Engine = engine;
            Word = word;
            Total = total;
        }
    }
}

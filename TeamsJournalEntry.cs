using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class TeamsJournalEntry
    {
        public string Collection { get; set; }
        public string InfoAboutChange { get; set; }
        public int NumNew;

        public TeamsJournalEntry(string col, string inf, int num)
        {
            Collection = col;
            InfoAboutChange = inf;
            NumNew = num;
        }

        public override string ToString()
        {
            string s = "Collection " + Collection
                + "; Type of change: " + InfoAboutChange
                + "; Number of element " + NumNew;
            return s;
        }
    }
}

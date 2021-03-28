using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class TeamsJournal
    {
        private List<TeamsJournalEntry> listChanges = new List<TeamsJournalEntry>();

        public void TeamEventHandler(object s, TeamListHandlerEventArgs args)
        {
            listChanges.Add(new TeamsJournalEntry(args.Collection, args.TypeOfChange, args.NumChanged));
        }

        public override string ToString()
        {
            string s = "";
            foreach (TeamsJournalEntry x in listChanges)
                s += x.ToString() + "\n";
            return s;
        }
    }
}

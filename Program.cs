using System.Collections.Generic;
using System;

namespace laba1
{
    class Program
    {
        static void Main(string[] args)
        {
            ResearchTeamCollection col1 = new ResearchTeamCollection();
            ResearchTeamCollection col2 = new ResearchTeamCollection();
            col1.Collection = "Collection1";
            col2.Collection = "Collection2";

            TeamsJournal journal1 = new TeamsJournal();
            TeamsJournal journal2 = new TeamsJournal();

            col1.ResearchTeamAdded += journal1.TeamEventHandler;
            col1.ResearchTeamInserted += journal1.TeamEventHandler;

            col1.ResearchTeamInserted += journal2.TeamEventHandler;
            col2.ResearchTeamInserted += journal2.TeamEventHandler;

            col1.AddDefaults();
            col1.AddResearchTeams(new ResearchTeam());
            col2.AddDefaults();
            col2.AddResearchTeams(new ResearchTeam());

            col1.InsertAt(1, new ResearchTeam());
            col2.InsertAt(1, new ResearchTeam());
            col1.InsertAt(6, new ResearchTeam());
            col2.InsertAt(6, new ResearchTeam());

            Console.WriteLine("     ДОБАВЛЕНИЯ И ВСТАВКИ КОЛЛЕКЦИИ №1");
            Console.WriteLine(journal1.ToString());
            Console.WriteLine("     ВСТАВКИ КОЛЛЕКЦИЙ №1 И №2");
            Console.WriteLine(journal2.ToString());
        }
    }
}

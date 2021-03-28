﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace laba1
{
    class ResearchTeamCollection
    {
        public delegate void TeamListHandler(object source, TeamListHandlerEventArgs args);
        public event TeamListHandler ResearchTeamAdded;
        public event TeamListHandler ResearchTeamInserted;

        private List<ResearchTeam> resT;

        public string Collection { get; set; }

        public void AddDefaults()
        {
            resT = new List<ResearchTeam>();
            resT.Add(new ResearchTeam());
            if (ResearchTeamAdded != null)
                ResearchTeamAdded(this, new TeamListHandlerEventArgs(Collection, "Add element", 0));
        }

        public void AddResearchTeams(params ResearchTeam[] p)
        {
            for (int i = 0; i < p.Length; i++)
            {
                resT.Add(p[i]);
                if (ResearchTeamAdded != null)
                    ResearchTeamAdded(this, new TeamListHandlerEventArgs(Collection, "Add element", resT.Count - 1));
            }
        }

        public override string ToString()
        {
            string s = "";
            for (int i = 0; i < resT.Count; i++)
                s += resT[i].ToString() + "\n";
            return s;
        }

        public virtual string ToShortString()
        {
            string s = "";
            for (int i = 0; i < resT.Count; i++)
                s += resT[i].ToShortString() 
                    + " Публикаций: " 
                    + resT[i].PapersList.Count 
                    + " Участников: " 
                    + resT[i].Members.Count
                    + "\n";
            return s;
        }

        public void SortRegNum()
        {
            resT.Sort();
        }

        public void SortTopic()
        {
            resT.Sort(new ResearchTeam().Compare);
        }

        public void SortNumPapers()
        {
            resT.Sort(new ResTeamCompare().Compare);
        }

        public int MinRegNum
        {
            get
            {
                if (resT.Count != 0)
                {
                    return resT.Min(resTeam => resTeam.RegNum);
                }
                else return -1; 
            }
        }

        public IEnumerable<ResearchTeam> TwoYears
        {
            get
            {
                return resT.Where(resTeam => resTeam.Info == TimeFrame.TwoYears);
            }
        }

        public List<ResearchTeam> NGroup(int n)
        {
            var query = resT.GroupBy(x => x.PapersList.Count);
            foreach (var group in query)
                if (group.Key == n) return group.ToList();
            return new List<ResearchTeam>();
        }

        public void InsertAt(int j, ResearchTeam rt)
        {
            if (resT.Count - 1 >= j)
            {
                resT.Insert(j - 1, rt);
                ResearchTeamInserted(this, new TeamListHandlerEventArgs(Collection, "Insert element", j));
            }
            else
            {
                resT.Add(rt);
                if (ResearchTeamAdded != null)
                    ResearchTeamAdded(this, new TeamListHandlerEventArgs(Collection, "Add element", resT.Count - 1));
            }
        }

        public ResearchTeam this[int val]
        {
            get
            {
                return resT[val];
            }
            set
            {
                resT[val] = value;
            }
        }

        
    }
}

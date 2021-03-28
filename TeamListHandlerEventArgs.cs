using System;
using System.Collections.Generic;
using System.Text;

namespace laba1
{
    class TeamListHandlerEventArgs : EventArgs
    {
        public string Collection { get; set; }
        public string TypeOfChange { get; set; }
        public int NumChanged { get; set; }

        public TeamListHandlerEventArgs(string collec, string type, int num)
        {
            Collection = collec;
            TypeOfChange = type;
            NumChanged = num;
        }

        public TeamListHandlerEventArgs()
        {
            Collection = "_";
            TypeOfChange = "_";
            NumChanged = 0;
        }

        public override string ToString()
        {
            string s = "Collection "
                + Collection + "; Type of change "
                + TypeOfChange + "; Number of change element "
                + NumChanged;
            return s;
        }
    }
}

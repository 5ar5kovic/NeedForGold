using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace NeedForGold
{
    class Igrac : IComparable<Igrac>
    {
        public string username { get; set; }
        public int poeni { get; set; }
        public string baseid { get; set; }
        public int CompareTo(Igrac other)
        {
            if (this.baseid == other.baseid)
            {
                return 0;
            }
            else if (this.poeni < other.poeni)
            {
                    return 1;
            }
            else
            {
                    return -1;
            }
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Linq;

namespace TestWeek1
{
    public class Node
    {
        public int MinSeverity { get; set; }
        public int MaxSeverity { get; set; }
        public List<string> Defenses { get; set; }
        public Node Left { get; set; }
        public Node Right { get; set; }
        public Node(int minSeverity, int maxSeverity,
        List<string> defenses)
        {
            MinSeverity = minSeverity;
            MaxSeverity = maxSeverity;
            Defenses = defenses;
            Left = null;
            Right = null;
        }
        
        
        public bool InRange(int severity)
        {
            return severity >= MinSeverity && severity <= MaxSeverity;
        }

        public override string ToString()
        {
            return $"[{MinSeverity}-{MaxSeverity}] defences:{string.Join(",", Defenses)}";
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestWeek1
{
    public static class Utillies
    {

        public static int CalculateSeverity(Threat threat)
        {
            int targetValue = threat.Target switch
            {
                "Web Server" => 10,
                "Database" => 15,
                "User Credentials" => 20,
                _ => 5
            };
            return (threat.Volume * threat.Sophistication) + targetValue;
        }
        public static void ActiveDefence(List<Threat> threats, BSTree tree)
        {
            
            foreach (Threat threat in threats)
            {
                int severity = CalculateSeverity(threat);
                List<string> defences = tree.Search(severity);
                if (defences.Count == 0)
                {
                    int minSeverity = tree.FindMinSeverity();
                    if (minSeverity > severity)
                    {
                        Console.WriteLine("Attack severity is below the threshold. Attack is ignored");
                    }
                    else
                    {
                        Console.WriteLine("No suitable defence was found. Brace for impact!");
                    }

                }
                foreach (string defence in defences)
                {
                    Console.WriteLine(defence);
                    Thread.Sleep(2000);
                }

            }
        }
    }
}

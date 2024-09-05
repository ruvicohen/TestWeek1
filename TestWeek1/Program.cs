using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Channels;
using System.Threading.Tasks;
using TestWeek1.Utilities;

namespace TestWeek1
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("");
            BSTree tree = new BSTree();
            List<Node> nodes = JsonUtilities.ReadFromJsonAsync<List<Node>>("../../../Json/defenceStrategies.json");
            nodes.ForEach(tree.Insert);
            Thread.Sleep(4000);
            Console.WriteLine("\n\nNot balance tree\n\n");
            tree.PrintTree();
            tree.Balance();
            List<Node> inOrder = tree.InOrder();
            Thread.Sleep(4000);
            Console.WriteLine("\n\nBalance tree in order list\n\n");
            Console.WriteLine(string.Join(",", inOrder));
            Thread.Sleep(4000);
            Console.WriteLine("\n\nBalance tree\n\n");
            tree.PrintTree();
            List<Threat> threats = JsonUtilities.ReadFromJsonAsync<List<Threat>>("../../../Json/threats.json");
            Thread.Sleep(4000);
            Console.WriteLine("\n\nActive defence\n\n");
            Utillies.ActiveDefence(threats, tree);
            List<Node> preOrder = tree.PreOrder();
            Console.WriteLine(string.Join(",", preOrder));
            JsonUtilities.WriteToJsonFileAsync("../../../Json/newThreats.json", threats);

        }
    }
}

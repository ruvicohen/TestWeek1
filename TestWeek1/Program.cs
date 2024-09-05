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

            // Create a new binary search tree
            BSTree tree = new BSTree();

            // Read a list of nodes from a JSON file and store it in 'nodes'
            List<Node> nodes = JsonUtilities.ReadFromJsonAsync<List<Node>>("../../../Json/defenceStrategies.json");

            // Insert each node from the list into the binary search tree
            nodes.ForEach(tree.Insert);

            Thread.Sleep(4000);

            // Print a message indicating the tree is not balanced
            Console.WriteLine("\n\nNot balance tree\n\n");

            // Print the current state of the tree
            tree.PrintTree();

            // Balance the binary search tree
            tree.Balance();

            // Get the list of nodes in in-order traversal from the balanced tree
            List<Node> inOrder = tree.InOrder();

            Thread.Sleep(4000);

            // Print a message and the in-order list of the balanced tree
            Console.WriteLine("\n\nBalance tree in order list\n\n");
            Console.WriteLine(string.Join(Environment.NewLine, inOrder));

            Thread.Sleep(4000);

            // Print a message indicating the balanced tree
            Console.WriteLine("\n\nBalance tree\n\n");

            // Print the current state of the balanced tree
            tree.PrintTree();

            // Read a list of threats from a JSON file and store it in 'threats'
            List<Threat> threats = JsonUtilities.ReadFromJsonAsync<List<Threat>>("../../../Json/threats.json");

            Thread.Sleep(4000);

            // Print a message and perform active defense 
            Console.WriteLine("\n\nActive defence\n\n");
            Utillies.ActiveDefence(threats, tree);

            // Get the list of nodes in pre-order traversal from the balanced tree
            List<Node> preOrder = tree.PreOrder();

            // Write the updated threats to a new JSON file
            JsonUtilities.WriteToJsonFileAsync("../../../Json/newBalanceTree.json", preOrder);
        }
    }
}

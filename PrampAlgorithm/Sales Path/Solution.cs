using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Sales_Path
{
    public class Solution
    {
        public class Node
        {
            public int cost;
            public Node[] children;
            public Node parent;
            public Node(int val)
            {
                cost = val;
                children = null;
                parent = null;
            }
        }

        public int getCheapestCost(Node rootNode)
        {
            if (rootNode == null) return 0;
            if (rootNode.children == null) return rootNode.cost;
            int ans = int.MaxValue;
            foreach (var child in rootNode.children)
                ans = Math.Min(ans, getCheapestCost(child));
            return ans + rootNode.cost;
        }

        public void Run()
        {
            Node root = new Node(0);
            root.children = new Node[3];

            root.children[0] = new Node(5);
            root.children[1] = new Node(3);
            root.children[2] = new Node(6);

            root.children[0].children = new Node[1];
            root.children[0].children[0] = new Node(4);

            root.children[1].children = new Node[2];
            root.children[1].children[0] = new Node(2);
            root.children[1].children[1] = new Node(0);

            root.children[1].children[0].children = new Node[1];
            root.children[1].children[0].children[0] = new Node(1);
            root.children[1].children[0].children[0].children = new Node[1];
            root.children[1].children[0].children[0].children[0] = new Node(1);

            root.children[1].children[1].children = new Node[1];
            root.children[1].children[1].children[0] = new Node(10);

            root.children[2].children = new Node[2];

            root.children[2].children[0] = new Node(1);
            root.children[2].children[1] = new Node(5);

            Console.WriteLine(getCheapestCost(root));
        }
    }
}

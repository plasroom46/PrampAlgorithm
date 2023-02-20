using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Largest_Smaller_BST_Key
{
    public class Node
    {
        public int key;
        public Node left;
        public Node right;
        public Node parent;

        public Node(int val)
        {
            key = val;
            left = null;
            right = null;
            parent = null;
        }
    }
}

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace PrampAlgorithm.Largest_Smaller_BST_Key
{
    // Space Complexity: O(h) = O(logn)
    public class Solution_V1
    {
        public class BinarySearchTree
        {
            Node root;

            public int findLargestSmallerKey(int num)
            {
                int ans = -1;
                Inorder(root, num, ref ans);
                return ans;
            }

            private void Inorder(Node rootNode, int num, ref int ans)
            {
                if (rootNode == null) return;
                if (rootNode.key < num)
                {
                    ans = rootNode.key;
                    Inorder(rootNode.right, num, ref ans);
                }
                else Inorder(rootNode.left, num, ref ans);
            }

            //  inserts a new node with the given number in the
            //  correct place in the tree
            public void insert(int key)
            {

                // 1) If the tree is empty, create the root
                if (this.root == null)
                {
                    this.root = new Node(key);
                    return;
                }

                // 2) Otherwise, create a node with the key
                //    and traverse down the tree to find where to
                //    to insert the new node
                Node currentNode = this.root;
                Node newNode = new Node(key);

                while (currentNode != null)
                {
                    if (key < currentNode.key)
                    {
                        if (currentNode.left == null)
                        {
                            currentNode.left = newNode;
                            newNode.parent = currentNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.left;
                        }
                    }
                    else
                    {
                        if (currentNode.right == null)
                        {
                            currentNode.right = newNode;
                            newNode.parent = currentNode;
                            break;
                        }
                        else
                        {
                            currentNode = currentNode.right;
                        }
                    }
                }
            }
        }

        public void Run()
        {
            BinarySearchTree bst = new BinarySearchTree();
            bst.insert(20);
            bst.insert(9);
            bst.insert(25);
            bst.insert(5);
            bst.insert(12);
            bst.insert(11);
            bst.insert(14);

            int result = bst.findLargestSmallerKey(17);
            Console.WriteLine("Largest smaller number is " + result);
        }
    }
}

namespace DataStructure
{
    using System;

    public class NTreeNode
    {
        public int Value { get; set; }
        public NTreeNode Left { get; set; }
        public NTreeNode Right { get; set; }

        public NTreeNode(int value)
        {
            this.Value = value;
            this.Left = null;
            this.Right = null;
        }
    }
    public class NTree
    {
        public NTree()
        {
        }
        public NTreeNode Root { get; set; }

        public NTreeNode Insert(NTreeNode node, int value)
        {
            if (node == null)
            {
                node = new NTreeNode(value);
                return node;
            }
            else
            {
                if (node.Value <= value)
                {
                    node.Right = Insert(node.Right, value);
                }
                else
                {
                    node.Left = Insert(node.Left, value);
                }
                return node;
            }
        }
        public NTreeNode Insert_Iterative(NTreeNode root, int value)
        {
            NTreeNode node = root;
            if (node == null)
            {
                root = new NTreeNode(value);
                return root;
            }
            while (node != null)
            {
                if (value < node.Value)
                {
                    if (node.Left == null)
                    {
                        node.Left = new NTreeNode(value);
                        return root;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new NTreeNode(value);
                        return root;
                    }
                    node = node.Right;
                }
            }
            return root;
        }

        public void InOrder(NTreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.Left);
            Console.Write($"{root.Value}, ");
            InOrder(root.Right);
        }
        public void InOrderIterative(NTreeNode root)
        {
            Stack<NTreeNode> stack = new Stack<NTreeNode>();
            NTreeNode current = root;
            bool done = false;
            while (!done)
            {
                if (current != null)
                {
                    stack.Push(current);
                    current = current.Left;
                }
                else
                {
                    if (stack.IsEmpty())
                    {
                        done = true;
                    }
                    else
                    {
                        current = stack.Peek();
                        stack.Pop();
                        Console.Write($"{current.Value}, ");
                        current = current.Right;
                    }
                }
            }
        }
        public void PreOrder(NTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write($"{root.Value}, ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
        public void POSTOrder(NTreeNode root)
        {
            if (root == null)
            {
                return;
            }
            POSTOrder(root.Left);
            POSTOrder(root.Right);
            Console.Write($"{root.Value}, ");
        }
        /* 
            Compute the number of nodes in a tree. 
        */
        public int Size(NTreeNode node)
        {
            if (node == null) return 0;

            return (Size(node.Left) + 1 + Size(node.Right));
        }
        /* 
         Compute the "maxDepth" of a tree -- the number of nodes along 
         the longest path from the root node down to the farthest leaf node. 
        */
        public int MaxDepth(NTreeNode node)
        {
            if (node == null) return 0;

            int leftDepth = MaxDepth(node.Left);
            int rightDepth = MaxDepth(node.Right);

            return Math.Max(leftDepth, rightDepth) + 1;
        }

        /* 
         Given a non-empty binary search tree, 
         return the minimum data value found in that tree. 
         Note that the entire tree does not need to be searched. 
        */
        public int MinValue(NTreeNode root)
        {
            NTreeNode node = root;

            while (node.Left != null)
            {
                node = node.Left;
            }

            return node.Value;
        }
        /* 
         Given a non-empty binary search tree, 
         return the maximum data value found in that tree. 
         Note that the entire tree does not need to be searched. 
        */
        public int MaxValue(NTreeNode root)
        {
            NTreeNode node = root;

            while (node.Right != null)
            {
                node = node.Right;
            }

            return node.Value;
        }
        /* 
         Given a tree and a sum, return true if there is a path from the root 
         down to a leaf, such that adding up all the values along the path 
         equals the given sum. 
         Strategy: subtract the node value from the sum when recurring down, 
         and check to see if the sum is 0 when you run out of tree. 
        */

        public bool HasPathSum(NTreeNode root)
        {
            return false;
        }
    }
}

﻿namespace DataStructure
{
    using System;
    using System.Collections.Generic;

    public class TreeNode
    {
        public int Value { get; set; }
        public TreeNode Left { get; set; }
        public TreeNode Right { get; set; }

        public TreeNode(int value)
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
        public TreeNode Root { get; set; }
        public TreeNode Insert(TreeNode node, int value)
        {
            if (node == null)
            {
                node = new TreeNode(value);
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
        public TreeNode Insert_Iterative(TreeNode root, int value)
        {
            TreeNode node = root;
            if (node == null)
            {
                root = new TreeNode(value);
                return root;
            }
            while (node != null)
            {
                if (value < node.Value)
                {
                    if (node.Left == null)
                    {
                        node.Left = new TreeNode(value);
                        return root;
                    }
                    node = node.Left;
                }
                else
                {
                    if (node.Right == null)
                    {
                        node.Right = new TreeNode(value);
                        return root;
                    }
                    node = node.Right;
                }
            }
            return root;
        }
        public void InOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }

            InOrder(root.Left);
            Console.Write($"{root.Value}, ");
            InOrder(root.Right);
        }
        public void InOrderIterative(TreeNode root)
        {
            Stack<TreeNode> stack = new Stack<TreeNode>();
            TreeNode current = root;
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
        public void PreOrder(TreeNode root)
        {
            if (root == null)
            {
                return;
            }
            Console.Write($"{root.Value}, ");
            PreOrder(root.Left);
            PreOrder(root.Right);
        }
        /* Pop all items one by one. Do following for every popped item
         a) print it
         b) push its right child
         c) push its left child
         Note that right child is pushed first so that left is processed first */
        public void PreOrderIterative(TreeNode root)
        {
            if (root == null) return;

            Stack<TreeNode> stack = new Stack<TreeNode>();
            stack.Push(root);

            while (!stack.IsEmpty())
            {
                TreeNode current = stack.Peek();
                Console.Write($"{current.Value}, ");
                stack.Pop();
                if (current.Right != null) stack.Push(current.Right);
                if (current.Left != null) stack.Push(current.Left);
            }

        }
        public void POSTOrder(TreeNode root)
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
         * 1.1 Create an empty stack
            2.1 Do following while root is not NULL
                a) Push root's right child and then root to stack.
                b) Set root as root's left child.
            2.2 Pop an item from stack and set it as root.
                a) If the popped item has a right child and the right child 
                   is at top of stack, then remove the right child from stack,
                   push the root back and set root as root's right child.
                b) Else print root's data and set root as NULL.
            2.3 Repeat steps 2.1 and 2.2 while stack is not empty.
         */
        public void POSTOrderIterative(TreeNode root)
        {
            if (root == null) return;
            Stack<TreeNode> stack = new Stack<TreeNode>();
            do
            {
                while (root != null)
                {
                    if (root.Right != null) stack.Push(root.Right); //Push the right tree
                    stack.Push(root);
                    root = root.Left; // Move to Left Tree
                }
                root = stack.Pop();
                if (root.Right != null && !stack.IsEmpty() && stack.Peek() == root.Right)
                {
                    //Swap Root and Right in Stack, so that we can process root later.
                    stack.Pop(); //remove Right
                    stack.Push(root); // push Root
                    root = root.Right; // Move to Right Tree
                }
                else
                {
                    Console.Write($"{ root.Value }, ");
                    root = null; // Done with This tree , move to next in stack
                }
            } while (!stack.IsEmpty());

        }
        public void PrintPaths(TreeNode root)
        {
            int[] paths = new int[1000];
            PrintPathRecurs(root, paths, 0);
        }
        private void PrintPathRecurs(TreeNode root, int[] paths, int length)
        {
            if (root == null) return;

            paths[length] = root.Value;
            length++;

            if (root.Left == null && root.Right == null) PrintPath(paths, length);
            else
            {
                PrintPathRecurs(root.Left, paths, length);
                PrintPathRecurs(root.Right, paths, length);
            }
        }
        private void PrintPath(int[] paths, int length)
        {
            for (int i = 0; i < length; i++)
            {
                Console.Write($"{paths[i]}, ");
            }
            Console.Write("\n");
        }
        /* 
            Compute the number of nodes in a tree. 
        */
        public int Size(TreeNode node)
        {
            if (node == null) return 0;

            return (Size(node.Left) + 1 + Size(node.Right));
        }
        /* 
         Compute the "maxDepth" of a tree -- the number of nodes along 
         the longest path from the root node down to the farthest leaf node. 
        */
        public int MaxDepth(TreeNode node)
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
        public int MinValue(TreeNode root)
        {
            TreeNode node = root;

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
        public int MaxValue(TreeNode root)
        {
            TreeNode node = root;

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
        public bool HasPathSum(TreeNode root, int sum)
        {
            bool ans = false;
            int subsum = sum - root.Value;
            if (subsum == 0 && root.Left == null && root.Right == null)
                return true;
            if (root.Left != null)
                ans = ans || HasPathSum(root.Left, subsum);
            if (root.Right != null)
                ans = ans || HasPathSum(root.Right, subsum);
            return ans;
        }
        public TreeNode Find(TreeNode node, int value)
        {
            if (node == null) return null;
            if (value == node.Value) return node;
            else if (value < node.Value) return Find(node.Left, value);
            else return Find(node.Right, value);
        }
        public TreeNode FindParent(TreeNode node, int value)
        {
            if (value == node.Value) return null;
            else if (value < node.Value)
            {
                if (node.Left == null) return null;
                if (node.Left.Value == value) return node;
                else return FindParent(node.Left, value);
            }
            else
            {
                if (node.Right == null) return null;
                if (node.Right.Value == value) return node;
                else return FindParent(node.Right, value);
            }
        }
        /*
        1. the value to remove is a leaf node; or 
        2. the value to remove has a right subtree, but no left subtree; or 
        3. the value to remove has a left subtree, but no right subtree; or 
        4. the value to remove has both a left and right subtree in which case we promote the largest value in the left subtree.
        */
        public void Remove(TreeNode root, int value)
        {
            TreeNode node = Find(root, value);
            if (node == null) return;
            int size = Size(root);
            TreeNode parent = FindParent(root, value);
            if (size == 1) root = null;
            else if (node.Left == null && node.Right == null)
            {
                if (node.Value < parent.Value) parent.Left = null;
                else parent.Right = null;
            }
            else if (node.Left == null && node.Right != null)
            {
                if (node.Value < parent.Value) parent.Left = node.Right;
                else parent.Right = node.Right;
            }
            else if (node.Left != null && node.Right == null)
            {
                if (node.Value < parent.Value) parent.Right = node.Left;
                else parent.Right = node.Left;
            }
            else
            {
                TreeNode largeteValue = node.Left;
                while (largeteValue.Right != null) largeteValue = largeteValue.Right;
                TreeNode largestNode = FindParent(root, largeteValue.Value);
                largestNode.Right = null;
                node.Value = largeteValue.Value;
            }
        }
        public void BreadthFirst(TreeNode root)
        {
            if (root == null) return;
            MyQueue<TreeNode> queue = new MyQueue<TreeNode>();
            queue.Enqueue(root);
            while (queue.Size() > 0)
            {
                root = queue.Dequeue();
                Console.Write($"{ root.Value}, ");
                if (root.Left != null) queue.Enqueue(root.Left);
                if (root.Right != null) queue.Enqueue(root.Right);
            }

        }
        public TreeNode GetSuccessor(TreeNode root,int value)
        {
            TreeNode current = Find(root, value);
            if (current == null) return null;
            if (current.Right != null)
            {
                TreeNode tmp = current.Right;
                while (tmp.Left != null) tmp = tmp.Left;
                return tmp;
            }
            else
            {
                TreeNode ancesotr = root;
                TreeNode successor = null;
                while (ancesotr != current)
                {
                    if (current.Value < ancesotr.Value)
                    {
                        successor = ancesotr;
                        ancesotr = ancesotr.Left;
                    }
                    else ancesotr = ancesotr.Right;
                }
                return successor;
            }
        }
        public int SumNumbers(TreeNode root)
        {
            var sum = SumNumbers(root, 0);
            return sum;
        }
        public int SumNumbers(TreeNode root, int val)
        {
            // Base case
            if (root == null)
                return 0;

            // Update val
            val = ((val) % 1003 * 10) % 1003 + (root.Value % 1003) % 1003;

            // if current node is leaf, return the current value of val
            if (root.Left == null && root.Right == null)
                return val;

            // recur sum of values for left and right subtree
            return (SumNumbers(root.Left, val) % 1003 + SumNumbers(root.Right, val) % 1003) % 1003;
        }
        public void ReversBreadthFirst(TreeNode root)
        {
            MyQueue<TreeNode> queue = new MyQueue<TreeNode>();
            Stack<TreeNode> stack = new Stack<TreeNode>();
            queue.Enqueue(root);

            while(queue.Size() > 0)
            {
                TreeNode node = queue.Dequeue();
                stack.Push(node);
                if (node.Right != null) queue.Enqueue(node.Right);
                if (node.Left != null) queue.Enqueue(node.Left);
            }
            while (!stack.IsEmpty())
            {
                Console.Write($"{ stack.Pop().Value}, ");
            }

        }
        public void ReversBreadthFirstIterative(TreeNode root)
        {
            int height = MaxDepth(root);
            for (int i = height; i >=1 ; i--)
            {
                PrintNodeAtLevel(root, i);
            }
        }
        public void PrintNodeAtLevel(TreeNode node,int level)
        {
            if (node == null) return;
            if (level == 1) Console.Write($"{node.Value}, ");
            else if(level>1)
            {
                PrintNodeAtLevel(node.Left, level - 1);
                PrintNodeAtLevel(node.Right, level - 1);
            }
        }
        public TreeNode CreateTreeFromLevelOrder(List<int> data)
        {
            MyQueue<TreeNode> queue = new MyQueue<TreeNode>();
            TreeNode root = new TreeNode(data[0]);
            TreeNode current = null;
            int childCount = 0;
            queue.Enqueue(root);
            for (int i = 1; i < data.Count; i++)
            {
                TreeNode node = data[i] != -1 ? new TreeNode(data[i]) : null;
                if (childCount == 0)
                {
                    current = queue.Dequeue();
                }
                if(childCount == 0)
                {
                    current.Left = node;
                    childCount++;
                }
                else
                {
                    current.Right = node;
                    childCount = 0;
                }
                if(node != null)
                {
                    queue.Enqueue(node);
                }
            }
            return root;
        }
        public TreeNode GetLeastCommonAncestor(TreeNode root,int n1,int n2)
        {
            if (root == null) return null;

            if (root.Value == n1 || root.Value == n2) return root;

            TreeNode left_lca = GetLeastCommonAncestor(root.Left, n1, n2);
            TreeNode right_lca = GetLeastCommonAncestor(root.Right, n1, n2);
            if (left_lca != null && right_lca != null) return root;

            return left_lca == null ? right_lca : left_lca;
        }
        public int FindLevel(TreeNode root,int value)
        {
            return FindLevel(root, value, 0);
        }
        private int FindLevel(TreeNode root, int value,int level)
        {
            if (root == null) return -1;
            if (root.Value == value) return level;

            int l = FindLevel(root.Left, value, level + 1);
            return (l != -1) ? l : FindLevel(root.Right, value, level + 1);
        }
        public int Distance(TreeNode root, int n1,int n2)
        {
            TreeNode lca = GetLeastCommonAncestor(root, n1, n2);
            int lca_level = FindLevel(root, lca.Value);
            int d1 = FindLevel(root, n1);
            int d2 = FindLevel(root, n2);

            return d1 + d2 - 2 * lca_level;
        }
    }
}

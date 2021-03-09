using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Lesson4_2
{
    public class MyBinaryTree : ITree
    {
        private TreeNode root;
        public void AddItem(int value)
        {
            TreeNode setNode = new TreeNode();
            setNode.Value = value;
            if (root == null)
                root = setNode;
            else
            {
                TreeNode temp = root;
                TreeNode parent = null;
                while (temp != null)
                {
                    parent = temp;

                    if (value < temp.Value)
                    {
                        temp = temp.LeftChild;
                        if (temp == null)
                        {
                            parent.LeftChild = setNode;
                        }
                    }
                    else
                    {
                        temp = temp.RightChild;
                        if (temp == null)
                        {
                            parent.RightChild = setNode;
                        }
                    }
                }
            }
        }

        public TreeNode GetNodeByValue(int value)
        {
            if (root != null)
            {
                TreeNode findeNode = root;

                while (findeNode != null)
                {
                    if (value == findeNode.Value)
                    {
                        return findeNode;
                    }
                    else if (value > findeNode.Value)
                    {
                        findeNode = findeNode.RightChild;
                    }
                    else
                    {
                        findeNode = findeNode.LeftChild;
                    }
                }
                return null;
            }
            else
            {
                return null;
            }
        }


        public TreeNode GetRoot() => root;

        public TreeNode Root { get { return root; } }
        public void PrintTree()
        {
            Root.Print();
        }

        public TreeNode GetSuccessor(TreeNode delNode)
        {
            TreeNode successorParent = delNode;
            TreeNode successor = delNode;
            TreeNode current = delNode.RightChild;

            while (!(current == null))
            {
                successorParent = current;
                successor = current;
                current = current.LeftChild;
            }

            if (!(successor == delNode.RightChild))
            {
                successorParent.LeftChild = successor.RightChild;
                successor.RightChild = delNode.RightChild;
            }
            successor.LeftChild = delNode.LeftChild;
            return successor;
        }


        public void RemoveItem(int value)
        {

            TreeNode current = root;
            TreeNode parent = root;
            bool isLeftChild = false;

            if (current == null)
            {
                return;
            }


            while (current != null && current.Value != value)
            {
                parent = current;

                if (value < current.Value)
                {
                    current = current.LeftChild;
                    isLeftChild = true;
                }
                else
                {
                    current = current.RightChild;
                    isLeftChild = false;
                }
            }

            if (current == null)
            {
                return;
            }

            if (current.RightChild == null && current.LeftChild == null)
            {
                if (current == root)
                {
                    root = null;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = null;
                    }
                    else
                    {
                        parent.RightChild = null;
                    }
                }
            }
            else if (current.RightChild == null)
            {
                if (current == root)
                {
                    root = current.LeftChild;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = current.LeftChild;
                    }
                    else
                    {
                        parent.RightChild = current.LeftChild;
                    }
                }
            }
            else if (current.LeftChild == null)
            {
                if (current == root)
                {
                    root = current.RightChild;
                }
                else
                {
                    if (isLeftChild)
                    {
                        parent.LeftChild = current.RightChild;
                    }
                    else
                    {
                        parent.RightChild = current.RightChild;
                    }
                }
            }
            else
            {
                TreeNode successor = GetSuccessor(current);

                if (current == root)
                {
                    root = successor;
                }
                else if (isLeftChild)
                {
                    parent.LeftChild = successor;
                }
                else
                {
                    parent.RightChild = successor;
                }

            }
        }


    }
}

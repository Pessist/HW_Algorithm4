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


        public void RemoveItem(int value)
        {
            //Проверяем, существует ли данный узел
            TreeNode deleteTreeNode = GetNodeByValue(value);

            if (deleteTreeNode == null)
            {
                //Если узла не существует, вернем false
                return;
            }

            TreeNode currentTree;

            //Если удаляем корень
            if (deleteTreeNode == root)
            {
                if (deleteTreeNode.RightChild != null)
                {
                    currentTree = deleteTreeNode.RightChild;
                }
                else currentTree = deleteTreeNode.LeftChild;

                while (currentTree.LeftChild != null)
                {
                    currentTree = currentTree.LeftChild;
                }
                int temp = currentTree.Value;
                RemoveItem(temp);
                deleteTreeNode.Value = temp;

                return;
            }


            //Удаление листьев
            if (deleteTreeNode.LeftChild == null && deleteTreeNode.RightChild == null && deleteTreeNode.Parent != null)
            {
                if (deleteTreeNode == deleteTreeNode.Parent.LeftChild)
                    deleteTreeNode.Parent.LeftChild = null;
                else
                {
                    deleteTreeNode.Parent.RightChild = null;
                }
                return;
            }

            //Удаление узла, имеющего левое поддерево, но не имеющее правого поддерева
            if (deleteTreeNode.LeftChild != null && deleteTreeNode.RightChild == null)
            {
                //Меняем родителя
                deleteTreeNode.LeftChild.Parent = deleteTreeNode.Parent;
                if (deleteTreeNode == deleteTreeNode.Parent.LeftChild)
                {
                    deleteTreeNode.Parent.LeftChild = deleteTreeNode.LeftChild;
                }
                else if (deleteTreeNode == deleteTreeNode.Parent.RightChild)
                {
                    deleteTreeNode.Parent.RightChild = deleteTreeNode.LeftChild;
                }
                return;
            }

            //Удаление узла, имеющего правое поддерево, но не имеющее левого поддерева
            if (deleteTreeNode.LeftChild == null && deleteTreeNode.RightChild != null)
            {
                //Меняем родителя
                deleteTreeNode.RightChild.Parent = deleteTreeNode.Parent;
                if (deleteTreeNode == deleteTreeNode.Parent.LeftChild)
                {
                    deleteTreeNode.Parent.LeftChild = deleteTreeNode.RightChild;
                }
                else if (deleteTreeNode == deleteTreeNode.Parent.RightChild)
                {
                    deleteTreeNode.Parent.RightChild = deleteTreeNode.RightChild;
                }
                return;
            }

            //Удаляем узел, имеющий поддеревья с обеих сторон
            if (deleteTreeNode.RightChild != null && deleteTreeNode.LeftChild != null)
            {
                currentTree = deleteTreeNode.RightChild;

                while (currentTree.LeftChild != null)
                {
                    currentTree = currentTree.LeftChild;
                }

                //Если самый левый элемент является первым потомком
                if (currentTree.Parent == deleteTreeNode)
                {
                    currentTree.LeftChild = deleteTreeNode.LeftChild;
                    deleteTreeNode.LeftChild.Parent = currentTree;
                    currentTree.Parent = deleteTreeNode.Parent;
                    if (deleteTreeNode == deleteTreeNode.Parent.LeftChild)
                    {
                        deleteTreeNode.Parent.LeftChild = currentTree;
                    }
                    else if (deleteTreeNode == deleteTreeNode.Parent.RightChild)
                    {
                        deleteTreeNode.Parent.RightChild = currentTree;
                    }
                    return;
                }
                //Если самый левый элемент НЕ является первым потомком
                else
                {
                    if (currentTree.RightChild != null)
                    {
                        currentTree.RightChild.Parent = currentTree.Parent;
                    }
                    currentTree.Parent.LeftChild = currentTree.RightChild;
                    currentTree.RightChild = deleteTreeNode.RightChild;
                    currentTree.LeftChild = deleteTreeNode.LeftChild;
                    deleteTreeNode.LeftChild.Parent = currentTree;
                    deleteTreeNode.RightChild.Parent = currentTree;
                    currentTree.Parent = deleteTreeNode.Parent;
                    if (deleteTreeNode == deleteTreeNode.Parent.LeftChild)
                    {
                        deleteTreeNode.Parent.LeftChild = currentTree;
                    }
                    else if (deleteTreeNode == deleteTreeNode.Parent.RightChild)
                    {
                        deleteTreeNode.Parent.RightChild = currentTree;
                    }

                    return;
                }
            }
            return;

        }


    }
}

using System;

namespace Lesson4_2
{
    class Program
    {
        static void Main(string[] args)
        {

            var binaryTree = new MyBinaryTree();

            binaryTree.AddItem(50);
            binaryTree.AddItem(45);
            binaryTree.AddItem(58);
            binaryTree.AddItem(55);
            binaryTree.AddItem(90);
            binaryTree.AddItem(95);
            binaryTree.AddItem(80);
            binaryTree.AddItem(1);
            binaryTree.AddItem(49);

            var findeNode = binaryTree.GetNodeByValue(80);

            binaryTree.RemoveItem(80);

            var getRoot = binaryTree.GetRoot();

            binaryTree.PrintTree();

        }
    }
}

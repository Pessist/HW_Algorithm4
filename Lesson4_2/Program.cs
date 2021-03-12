using System;
using System.Collections.Generic;
using System.Linq;

namespace Lesson4_2
{
    class Program
    {
        public class TestCase
        {
            public int AddNode { get; set; }
            public int GetNode { get; set; }
            public int RemoveNode { get; set; }
            public int Depth { get; set; }
        }

        static void Main(string[] args)
        {
            var binaryTree = new MyBinaryTree();

            // Тест на добавление и поиск ноды 
            var testData = new TestCase[6];
            testData[0] = new TestCase()
            {
                AddNode = 50,
                GetNode = 50,
            };
            testData[1] = new TestCase()
            {
                AddNode = 45,
                GetNode = 45,
            };
            testData[2] = new TestCase()
            {
                AddNode = 58,
                GetNode = 58,
            };
            testData[3] = new TestCase()
            {
                AddNode = 55,
                GetNode = 55,
            };
            testData[4] = new TestCase()
            {
                AddNode = 90,
                GetNode = 50,
            };
            testData[5] = new TestCase()
            {
                AddNode = 95,
                GetNode = 45,
            };


            foreach (var testCase in testData)
            {

                binaryTree.AddItem(testCase.AddNode);
                var resultAdd = binaryTree.GetNodeByValue(testCase.AddNode);
                var expected = binaryTree.GetNodeByValue(testCase.GetNode);
                if (resultAdd == expected)
                {
                    Console.WriteLine("Все верно!");
                }
                else
                {
                    Console.WriteLine("Ошибка!");
                }

            }

            //Тест на правильность заполнения бинарного дерева

            var testData2 = new TestCase[6];
            testData2[0] = new TestCase()
            {
                GetNode = 50,
                Depth = 0,
            };
            testData2[1] = new TestCase()
            {
                GetNode = 45,
                Depth = 1,
            };
            testData2[2] = new TestCase()
            {
                GetNode = 58,
                Depth = 1,
            };
            testData2[3] = new TestCase()
            {
                GetNode = 55,
                Depth = 2,
            };
            testData2[4] = new TestCase()
            {
                GetNode = 90,
                Depth = 2,
            };
            testData2[5] = new TestCase()
            {
                GetNode = 95,
                Depth = 3,
            };


            Tuple<int, int>[] standart;
            var list = new List<Tuple<int, int>>(); // эталонный кортеж
            list.Add(Tuple.Create(50, 0));
            list.Add(Tuple.Create(45, 1));
            list.Add(Tuple.Create(58, 1));
            list.Add(Tuple.Create(55, 2));
            list.Add(Tuple.Create(90, 2));
            list.Add(Tuple.Create(95, 3));
            standart = list.ToArray();

            NodeInfo[] binaryArray;
            binaryArray = TreeHelper.GetTreeInLine(binaryTree);

            var validate = new Tuple<int, int>[binaryArray.Length]; // кортеж дя проверки

            for (int i = 0; i < binaryArray.Length; i++)
            {
                //Console.WriteLine(binaryArray[i]);

                int depth = binaryArray[i].Depth;
                int value = binaryArray[i].Node.Value;
                list.Add(Tuple.Create(value, depth));
                validate[i] = new Tuple<int, int>(value, depth);
                validate.ToArray();

                //Console.WriteLine($"глубина - {depth}, значение {value}");
            }

            Console.WriteLine("\n");

            if (standart == validate)
            {
                Console.WriteLine("Элементы дерева заполнены верно");
            }
            else
            {
                Console.WriteLine("Элементы дерева заполнены не верно");
            }

            Console.WriteLine("\n");

            //Тест на проверку удаления узла
            Console.WriteLine("Дерево до удаления нод:");
            binaryTree.PrintTree();

            var testData3 = new TestCase[2];
            testData3[0] = new TestCase()
            {
                RemoveNode = 45,
                GetNode = 45
            };
            testData3[1] = new TestCase()
            {
                RemoveNode = 55,
                GetNode = 55
            };


            foreach (var testCase in testData3)
            {
                binaryTree.RemoveItem(testCase.RemoveNode);
                var findNode = binaryTree.GetNodeByValue(testCase.GetNode);
                if (findNode == null)
                    Console.WriteLine("Все верно!");
                else
                    Console.WriteLine("Ошибка!");
            }

            Console.WriteLine("\n\nДерево после удаления нод 45 и 55:");
            binaryTree.PrintTree();

            //binaryTree.AddItem(50);
            //binaryTree.AddItem(45);
            //binaryTree.AddItem(58);
            //binaryTree.AddItem(55);
            //binaryTree.AddItem(90);
            //binaryTree.AddItem(95);
            //binaryTree.AddItem(80);
            //binaryTree.AddItem(1);
            //binaryTree.AddItem(49);

            //var findeNode = binaryTree.GetNodeByValue(80);

            //binaryTree.PrintTree();

            //Console.WriteLine("\n\n");

            //binaryTree.RemoveItem(1);

            //var getRoot = binaryTree.GetRoot();

            //Console.WriteLine("\n\n");

            //binaryTree.PrintTree();

        }
    }
}
